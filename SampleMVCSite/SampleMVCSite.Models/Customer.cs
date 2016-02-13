using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SampleMVCSite.Models
{
    public enum CreditCardType
    {
        VISA,
        MasterCard,
    }
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("Customer Name")]
        [Required]
        public string CustomerName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }

        [DisplayName("Postal Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [DisplayName("Home Phone")]
        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }

        [DisplayName("Business Phone")]
        [DataType(DataType.PhoneNumber)]
        public string BusinessPhone { get; set; }

        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DisplayName("Credit Card Number")]
        [DataType(DataType.CreditCard)]
        public string CreditCardNumber { get; set; }

        public CreditCardType CreditCardType { get; set; }

        [DisplayName("Orders")]
        public ICollection<Order> Order { get; set; }
    }
}
