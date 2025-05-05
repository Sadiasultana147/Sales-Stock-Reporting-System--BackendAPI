using Microsoft.EntityFrameworkCore;
using SSRS.Application.Interface.Product;
using SSRS.Domain;
using SSRS.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Infrastructure.Persistance.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Products product)
        {
            await _context.Products.AddAsync(product);
        }
        public async Task<List<Products>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Products?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public void UpdateProduct(Products product)
        {
            _context.Products.Update(product);
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                product.IsDeleted = true;
                _context.Products.Update(product);
            }
        }
    }
}
