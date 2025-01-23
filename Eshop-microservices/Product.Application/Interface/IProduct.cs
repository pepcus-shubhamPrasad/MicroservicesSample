using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Application.DTOs;

namespace Product.Application.Interface
{
    public interface IProduct
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> CreateProductAsync(ProductDTO productDto);
    }
}
