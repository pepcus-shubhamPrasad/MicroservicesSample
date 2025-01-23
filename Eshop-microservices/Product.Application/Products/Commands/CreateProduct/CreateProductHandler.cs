using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Application.Products.Queries.GetProducts;
using Product.Application.Wrappers;

namespace Product.Application.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<ProductDTO>>
    {
        private readonly IProduct _product;

        public CreateProductHandler(IProduct product)
        {
            _product = product;
        }
        public async Task<Result<ProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new ProductDTO
            {
                ProductId = new Random().Next(1, 1000), 
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                IsDeleted = false
            };
            var product = await _product.CreateProductAsync(newProduct);
            return await Task.FromResult(Result<ProductDTO>.Success(newProduct));
        }
    }
}
