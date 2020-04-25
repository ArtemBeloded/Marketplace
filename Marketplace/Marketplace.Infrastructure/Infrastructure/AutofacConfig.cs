using Autofac;

namespace Marketplace.Infrastructure.Infrastructure
{
    public class AutofacConfig
    {
        public static ContainerBuilder ConfigureContainer() 
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<ProductRepository>().As<IProductRepository>();
            //builder.RegisterType<ProductService>().As<IProductService>();
            return builder;
        }
    }
}
