using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Marketplace.BLL.Repositories;
using Marketplace.BLL.Services;
using Marketplace.DAL.DataBaseContext;
using Marketplace.DAL.Repositories;
using System.Configuration;
using System.Web;

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
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<IMapper>();
            
            return builder;
        }
    }
}
