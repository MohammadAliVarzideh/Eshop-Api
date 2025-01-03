﻿using Shop.Domain.OrderAgg.ValueObjects;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        private Order()
        {

        }
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
            Items = new List<OrderItem>();
        }

        public long UserId { get; private set; }

        public OrderStatus Status { get; private set; }

        public OrderDiscount? Discount { get; private set; }

        public OrderAddress? Address { get; private set; }

        public ShippingMethod? ShippingMethod { get; private set; }

        public List<OrderItem> Items { get; private set; }

        public DateTime? LastUpdate { get; set; }

        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(f => f.TotalPrice);
                if (ShippingMethod != null)
                    totalPrice -= ShippingMethod.ShippingCost;

                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }

        public int ItemCount => Items.Count;



        public void AddItem(OrderItem item)
        {
            ChangeOrderGuard();

            var oldItem = Items.FirstOrDefault(f => f.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                oldItem.ChangeCount(item.Count + oldItem.Count);
                return;
            }
            Items.Add(item);
        }


        public void RemoveItem(long itemId)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem != null)
                Items.Remove(currentItem);
        }

        public void ChangeCountItem(long itemId, int newCount)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.ChangeCount(newCount);
        }


        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Checkout(OrderAddress orderAddress)
        {
            ChangeOrderGuard();

            Address = orderAddress;
        }



        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pennding)
                throw new InvalidDomainDataException("امکان ثبت محصول در این سفارش وجود ندارد");

        }
    }



}
