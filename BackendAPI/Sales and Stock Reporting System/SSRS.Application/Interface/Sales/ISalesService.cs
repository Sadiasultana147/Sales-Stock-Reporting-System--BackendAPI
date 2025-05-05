using SSRS.Application.Features.Sales.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Interface.Sales
{
    public interface ISalesService
    {
        Task<string> CreateSaleAsync(SalesDTO saleDto);
        Task<List<SalesListDTO>> GetAllSalesAsync();
    }
}
