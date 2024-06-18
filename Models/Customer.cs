using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }


        [Required]
        public string CustomerName { get; set; }

        public int CustomerAge {  get; set; }

        public string CustomerPassword {  get; set; }

        public int CustomerPhone {  get; set; }

    }
}
