using Microsoft.AspNetCore.Mvc;
using SSRS.Application.Features.Product.DTO;
using SSRS.Application.Interface.Product;

namespace SSRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO dto)
        {

            if (dto == null)
            {
                return BadRequest("Product data is required.");
            }

            await _productService.CreateProductAsync(dto);
            return Ok(new { message = "Product created successfully." });
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var productList = await _productService.GetAllProductsAsync();
            var activeProducts = productList.Where(p => !p.IsDeleted).ToList();
            return Ok(activeProducts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound($"The Product of {id} not found.");
            }

            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("The ID not found.");
            }

            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound($"Product with ID {id} was not found.");
            }

            await _productService.UpdateProductAsync(productDto);
            return Ok(new { message = "Product updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} was not found.");
            }

            await _productService.DeleteProductAsync(id);
            return Ok(new { message = "Product soft deleted successfully." });
        }
    }
}
