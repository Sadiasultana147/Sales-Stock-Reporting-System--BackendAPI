using Microsoft.EntityFrameworkCore;
using SSRS.Application.Interface.Sales;
using SSRS.Domain.Entities;
using SSRS.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Infrastructure.Persistance.Repository
{
    public class SalesRepository: ISalesRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSaleAsync(SalesEntity sale)
        {
            await _context.Sales.AddAsync(sale);
        }

        public async Task<List<SalesEntity>> GetAllSalesAsync()
        {
            return await _context.Sales
                .Include(s => s.Product)
                .ToListAsync();
        }
    }
}

