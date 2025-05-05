using SSRS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Interface.Product
{
    public interface IProductRepository
    {
        Task AddAsync(Products product);
       
        Task<List<Products>> GetAllAsync();

        Task<Products?> GetProductByIdAsync(int id);
        void UpdateProduct(Products product);
        Task DeleteProductAsync(int id);

    }
}
