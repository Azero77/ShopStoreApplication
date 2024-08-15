using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    public class Product
    {
        public Product(int id, int? categoryId, int? modelNumber, string? modelName, decimal? cost, string? description)
        {
            Id = id;
            CategoryId = categoryId;
            ModelNumber = modelNumber;
            ModelName = modelName;
            Cost = cost;
            Description = description;
        }
        public Product()
        {
            
        }
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? ModelNumber { get; set; }
        public string? ModelName { get; set; }
        public decimal? Cost { get; set; }
        public string? Description { get; set; }

        public void EditProduct(Product p) 
        {
            Id = p.Id;
            CategoryId = p.CategoryId;
            ModelNumber = p.ModelNumber;
            ModelName = p.ModelName;
            Cost = p.Cost;
            Description = p.Description;
        }
    }
}
