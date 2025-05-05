using Autofac;
using SSRS.Application.Features.Product.Services;
using SSRS.Application.Features.Sales.Service;
using SSRS.Application.Features.UserManagement.Service;
using SSRS.Application.Interface;
using SSRS.Application.Interface.Product;
using SSRS.Application.Interface.Sales;
using SSRS.Application.Interface.UserManagement;
using SSRS.Infrastructure.Persistance;
using SSRS.Infrastructure.Persistance.JWT;
using SSRS.Infrastructure.Persistance.Repository;

namespace SSRS.DI
{
    public class WebModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<SalesRepository>().As<ISalesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SalesService>().As<ISalesService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtTokenGenerator>().As<IJwtTokenGenerator>().InstancePerLifetimeScope();


        }
    }
}
