using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Product.Application.DTOs;
using Product.Application.Wrappers;

namespace Product.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Result<ProductDTO>>
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
    }
}
