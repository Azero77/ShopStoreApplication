using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? ModelNumber { get; set; }
        public string? ModelName { get; set; }
        public decimal? Cost { get; set; }
        public string? Description { get; set; }

    }
}
