using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Could not get entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity is null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity is null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} couldn't be updated");
            }
        }
    }
}
