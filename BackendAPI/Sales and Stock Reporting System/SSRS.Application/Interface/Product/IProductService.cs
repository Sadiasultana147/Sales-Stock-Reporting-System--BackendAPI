using SSRS.Application.Features.Product.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Interface.Product
{
    public interface IProductService
    {
        Task CreateProductAsync(ProductDTO product);
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<UpdateProductDTO?> GetProductByIdAsync(int id);
        Task UpdateProductAsync(UpdateProductDTO product);
        Task DeleteProductAsync(int id);
    }
}
