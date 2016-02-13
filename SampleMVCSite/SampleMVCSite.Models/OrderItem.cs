using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SampleMVCSite.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [DisplayName("Product ID")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [DisplayName("Order ID")]
        public int OrderId { get; set; }
        [DisplayName("Order")]
        public virtual Order Order { get; set; }
    }
}
