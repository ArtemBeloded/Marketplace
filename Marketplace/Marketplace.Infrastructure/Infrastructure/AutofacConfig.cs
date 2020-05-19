using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Marketplace.BLL.Repositories;
using Marketplace.BLL.Services;
using Marketplace.DAL.DataBaseContext;
using Marketplace.DAL.Repositories;
using System.Configuration;

namespace Marketplace.Infrastructure.Infrastructure
{
    public class AutofacConfig
    {
        public static ContainerBuilder ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(x =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                return new MarketplaceContext(connectionString);
            }).AsSelf();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CartRepository>().As<ICartRepository>();
            builder.RegisterType<CartService>().As<ICartService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            
            return builder;
        }
    }
}
