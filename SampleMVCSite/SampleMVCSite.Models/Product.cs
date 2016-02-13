using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCSite.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required, MaxLength(255), DisplayName("Title")]
        public string Title { get; set; }

        [MaxLength(1023), DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("ImageUrl")]
        [DataType(DataType.ImageUrl)]
        [DefaultValue("/Content/img/no_image.jpg")]
        public string ImageUrl { get; set; }

        [MaxLength(255), DisplayName("Actors")]
        public string Actors { get; set; }

        [DisplayName("Publication Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Date { get; set; }

        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [DisplayName("Cost Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? CostPrice { get; set; }

        [DisplayName("Stock")]
        [DefaultValue(999)]
        public int? Stock { get; set; }

        [DisplayName("Order Items")]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
