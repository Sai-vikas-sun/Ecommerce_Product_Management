using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class Product
    {

        public Guid ProductId { get; set; }


        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }





    }
}
