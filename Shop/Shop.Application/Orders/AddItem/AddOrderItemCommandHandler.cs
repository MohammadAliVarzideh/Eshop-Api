using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly ISellerRepository _sellerRepository;

        public AddOrderItemCommandHandler(IOrderRepository repository, ISellerRepository sellerRepository)
        {
            _repository = repository;
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
            if (inventory == null)
                return OperationResult.NotFound();

            if (inventory.Count < request.Count)
                return OperationResult.Error("تعداد درخاستی بیشتر از موجدی محصول است");

            var order = await _repository.GetCurrentUserOrder(request.UserId);
            if (order == null)
                order = new Order(request.UserId);

            order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
            if (ItemCountBiggerThanInventoryCount(inventory, order))
                return OperationResult.Error("تعداد درخاستی بیشتر از موجدی محصول است");

            await _repository.Save();
            return OperationResult.Success();
        }

        private bool ItemCountBiggerThanInventoryCount(InventoryResult invetory, Order order)
        {
            var orderItem = order.Items.First(f => f.InventoryId == invetory.Id);
            if (orderItem.Count > invetory.Count)
                return true;

            return false;
        }

    }
}
