using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Product.Application.DTOs;
using Product.Application.Wrappers;

namespace Product.Application.Products.Queries.GetProducts
{
    public class GetProductListQuery : IRequest<Result<ICollection<ProductDTO>>>
    {
    }
}
