using SSRS.Application.Features.Sales.DTO;
using SSRS.Application.Interface;
using SSRS.Application.Interface.Sales;
using SSRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Features.Sales.Service
{
    public class SalesService: ISalesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CreateSaleAsync(SalesDTO saleDto)
        {
            var product = await _unitOfWork.Products.GetProductByIdAsync(saleDto.ProductId);

            if (product == null || product.IsDeleted)
            {
                return "Product not found or has been deleted.";
            }

            if (saleDto.QuantitySold <= 0)
            {
                return "Quantity must be greater than zero.";
            }

            if (saleDto.QuantitySold > product.StockQty)
            {
                return $"have Not enough stock. Total Stock: {product.StockQty}.";
            }

            var totalPrice = product.Price * saleDto.QuantitySold;

            var sale = new SalesEntity
            {
                ProductId = saleDto.ProductId,
                QuantitySold = saleDto.QuantitySold,
                TotalPrice = totalPrice,
                SaleDate = DateTime.Now
            };

            // Reduce product stock
            product.StockQty -= saleDto.QuantitySold;

            _unitOfWork.Sales.AddSaleAsync(sale);
            _unitOfWork.Products.UpdateProduct(product);

            await _unitOfWork.SaveChangesAsync();

            return "Sale completed successfully.";
        }
        public async Task<List<SalesListDTO>> GetAllSalesAsync()
        {
            var sales = await _unitOfWork.Sales.GetAllSalesAsync();

            return sales.Select(s => new SalesListDTO
            {
                Id = s.Id,
                ProductId = s.ProductId,
                ProductName = s.Product.Name,
                SKUCode = s.Product.SKU,
                Price = s.Product.Price,
                StockQuantity = s.Product.StockQty,
                QuantitySold = s.QuantitySold,
                TotalPrice = s.TotalPrice,
                SaleDate = s.SaleDate
            }).ToList();
        }

    }
}
