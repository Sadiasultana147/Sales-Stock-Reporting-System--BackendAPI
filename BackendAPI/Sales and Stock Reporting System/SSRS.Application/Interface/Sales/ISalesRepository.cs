using SSRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Interface.Sales
{
    public interface ISalesRepository
    {
        Task AddSaleAsync(SalesEntity sale);
        Task<List<SalesEntity>> GetAllSalesAsync();
    }
}
