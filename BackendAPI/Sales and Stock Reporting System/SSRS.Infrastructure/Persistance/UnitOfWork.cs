using SSRS.Application.Interface;
using SSRS.Application.Interface.Product;
using SSRS.Application.Interface.Sales;
using SSRS.Application.Interface.UserManagement;
using SSRS.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Infrastructure.Persistance
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository Products { get; }
        public ISalesRepository Sales { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext context, IProductRepository productRepository, ISalesRepository sales, IUserRepository users)
        {
            _context = context;
            Products = productRepository;
            Sales = sales;
            Users =users;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
