using SSRS.Application.Interface.Product;
using SSRS.Application.Interface.Sales;
using SSRS.Application.Interface.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ISalesRepository Sales { get; }
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
