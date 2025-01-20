using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
