using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDao : IProductDao
    {
        private readonly SalesDbContext _context;

        public ProductDao(SalesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> AddAsync(Product product)
        {
            await _context.AddAsync(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }
    }
}
