using ProductStore.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductStore.Controllers.DTO
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Product ConvertToProduct(AddProductRequest request)
        {
            Product product = new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = request.ProductName,
                Price = request.Price,
                Description = request.Description
            };
            return product;
        }
    }
}
