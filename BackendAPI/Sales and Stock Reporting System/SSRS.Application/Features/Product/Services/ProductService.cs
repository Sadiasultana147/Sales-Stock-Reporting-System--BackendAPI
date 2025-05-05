using SSRS.Application.Features.Product.DTO;
using SSRS.Application.Interface;
using SSRS.Application.Interface.Product;
using SSRS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Features.Product.Services
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProductAsync(ProductDTO product)
        {
            var newProduct = new Products
            {
                Name = product.Name,
                SKU = product.SKU,
                Price = product.Price,
                StockQty = product.StockQty,
                Description = product.Description,
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            return products.Select(p => new ProductDTO
            {
                Id=p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Price = p.Price,
                StockQty = p.StockQty,
                Description = p.Description,
                IsDeleted = p.IsDeleted,
                CreatedAt=p.CreatedAt
            }).ToList();
        }
        public async Task<UpdateProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetProductByIdAsync(id);

            if (product == null)
                return null;

            
            return new UpdateProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQty= product.StockQty,
                Description = product.Description
            };
        }

        public async Task UpdateProductAsync(UpdateProductDTO productDto)
        {
            var product = await _unitOfWork.Products.GetProductByIdAsync(productDto.Id);

            if (product == null)
            {
                return;
            }

            product.Name = productDto.Name;
            product.SKU = productDto.SKU;
            product.Price = productDto.Price;
            product.StockQty = productDto.StockQty;
            product.Description = productDto.Description;

            _unitOfWork.Products.UpdateProduct(product);

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            await _unitOfWork.Products.DeleteProductAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
