using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount : ValueObject
    {
        public OrderDiscount(string discounteTitle, int discountAmount)
        {
            DiscounteTitle = discounteTitle;
            DiscountAmount = discountAmount;
        }

        public string DiscounteTitle { get;private set; }

        public int DiscountAmount { get; private set; }

    }
}
