using Marketplace.Infrastructure.Infrastructure;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using AutoMapper;
using Autofac;
using Marketplace.Helpers;
using System.Configuration;

namespace Marketplace
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = AutoMapperConfig.ConfigureContainer(AutoMapperConfigHelper.AddWebMappings());
            builder.Register((x) => config.CreateMapper()).As(typeof(IMapper));

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}