using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    [Table("Product")]
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
