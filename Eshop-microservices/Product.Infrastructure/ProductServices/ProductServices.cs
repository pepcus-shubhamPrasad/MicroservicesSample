using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Infrastructure.ProductServices
{

    public class ProductServices : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductServices(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

    }
}
