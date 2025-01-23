using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.Application;
using Product.Application.DTOs;
using Product.Application.Interface;
using Product.Domain.Entities;

namespace Product.Infrastructure.ProductServices
{

    public class ProductServices : IProduct
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductServices(ApplicationDbContext dbContext , IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDto)
        {
            if (productDto == null)
            {
                throw new ArgumentNullException(nameof(productDto), "Product data cannot be null.");
            }
            var productEntity = _mapper.Map<Products>(productDto);
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

            var createdProductDto = new ProductDTO
            {
                ProductId = productEntity.ProductId,
                ProductName = productEntity.ProductName,
                ProductPrice = productEntity.ProductPrice,
                IsDeleted = productEntity.IsDeleted
            };

            return createdProductDto;
        }
    }
}
