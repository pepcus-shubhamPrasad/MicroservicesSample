using MediatR;
using Product.Application.DTOs;
using Product.Application.Products.Queries.GetProducts;
using Product.Application.Wrappers;
using Product.Infrastructure;
using Product.Domain.Interfaces;
using AutoMapper;

public class GetProductsHandler : IRequestHandler<GetProductListQuery, Result<ICollection<ProductDTO>>>
{
    private readonly ApplicationDbContext _context;
    private readonly IProduct _product;
    private readonly IMapper _mapper;

    public GetProductsHandler(ApplicationDbContext dbContext, IProduct product, IMapper mapper)
    {
        _context = dbContext;
        _product = product;
        _mapper = mapper;
    }

    public async Task<Result<ICollection<ProductDTO>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _product.GetAllProductsAsync();
            var productDTOs = _mapper.Map<ICollection<ProductDTO>>(products);
            return Result<ICollection<ProductDTO>>.Success(productDTOs, "Products fetched successfully.");
        }
        catch (Exception ex)
        {
            return Result<ICollection<ProductDTO>>.Failure("An error occurred while fetching products.", new List<string> { ex.Message });
        }
    }
}
