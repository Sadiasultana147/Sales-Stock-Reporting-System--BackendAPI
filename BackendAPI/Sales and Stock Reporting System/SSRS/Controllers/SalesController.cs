using Microsoft.AspNetCore.Mvc;
using SSRS.Application.Features.Sales.DTO;
using SSRS.Application.Features.Sales.Service;
using SSRS.Application.Interface.Sales;

namespace SSRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _saleService;

        public SalesController(ISalesService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SalesDTO saleDto)
        {
            var result = await _saleService.CreateSaleAsync(saleDto);

            if (result.Contains("success", StringComparison.OrdinalIgnoreCase))
                return Ok(new { message = result });

            return BadRequest(new { error = result });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var salesList = await _saleService.GetAllSalesAsync();
            return Ok(salesList);
        }

    }
}
