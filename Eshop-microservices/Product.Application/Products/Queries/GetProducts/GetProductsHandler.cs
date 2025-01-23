using MediatR;
using Product.Application.DTOs;
using Product.Application.Products.Queries.GetProducts;
using Product.Application.Wrappers;
using Product.Application;
using AutoMapper;
using Product.Application.Interface;

public class GetProductsHandler : IRequestHandler<GetProductListQuery, Result<ICollection<ProductDTO>>>
{
    private readonly IProduct _product;

    public GetProductsHandler(IProduct product)
    {
        _product = product;
    }

    public async Task<Result<ICollection<ProductDTO>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _product.GetAllProductsAsync();

            if (products == null || !products.Any())
            {
                return Result<ICollection<ProductDTO>>.Failure("No products found.");
            }

            return Result<ICollection<ProductDTO>>.Success(products.ToList(), "Products fetched successfully.");
        }
        catch (Exception ex)
        {
            return Result<ICollection<ProductDTO>>.Failure("An error occurred while fetching products.", new List<string> { ex.Message });
        }
    }
}
