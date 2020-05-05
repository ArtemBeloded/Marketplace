using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Marketplace.BLL.Services;
using Marketplace.DAL.Repositories;
using System.Web;

namespace Marketplace.Infrastructure.Infrastructure
{
    public class AutofacConfig
    {
        public static ContainerBuilder ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CartRepository>().As<ICartRepository>();
            builder.RegisterType<CartService>().As<ICartService>();
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<IMapper>();
            return builder;
        }
    }
}
