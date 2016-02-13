using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleMVCSite.Models
{
    public enum OrderStatus
    {
        Ordered,
        Shipped,
        Delivered,
        Canceled
    }

    public class Order
    {
        public int OrderId { get; set; }

        [DisplayName("Order Date")]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:G}")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Customer")]
        public virtual Customer Customer { get; set; }

        public OrderStatus Status { get; set; }

        [DisplayName("Order Items")]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
