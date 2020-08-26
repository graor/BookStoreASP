using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; } 
        public OrderStatus OrderStatus{ get; set; }
        public string Address { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
        public virtual User User { get; set; }


    }

    public enum OrderStatus
    {
        Received,
        Delivered,
        Shipped,
        Canceled
    }
}
