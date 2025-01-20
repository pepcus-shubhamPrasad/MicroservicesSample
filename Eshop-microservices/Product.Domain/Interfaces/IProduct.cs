using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Domain.Entities;

namespace Product.Domain.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
    }
}
