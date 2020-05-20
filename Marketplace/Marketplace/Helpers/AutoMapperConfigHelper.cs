using AutoMapper;
using Marketplace.DAL.Models;
using Marketplace.Models;
using System;
using System.Web;

namespace Marketplace.Helpers
{
    public class AutoMapperConfigHelper
    {
        public static Action<IMapperConfigurationExpression> AddWebMappings()
        {
            return (cfg) =>
            {
                cfg.CreateMap<Product, CreateProductVM>();
                cfg.CreateMap<CreateProductVM, Product>()
                .ForMember(x => x.Photo, config =>
                    config.MapFrom((dest) => ConvertHttpPostedFileBaseToString(dest.Photo)));

                cfg.CreateMap<Product, ShowProductVM>();
                cfg.CreateMap<ShowProductVM, Product>();

                cfg.CreateMap<Product, UpdateProductVM>();
                cfg.CreateMap<UpdateProductVM, Product>();

                cfg.CreateMap<CartLine, CartLineVM>();

                cfg.CreateMap<Product, ProductCartLineVM>();

                cfg.CreateMap<CredentialVM, Credential>();
                cfg.CreateMap<RegistrationUserVM, User>()
                .ForMember(x => x.RoleId, config => config.MapFrom(x => x.Role))
                .ForMember(x => x.Role, config => config.Ignore());

            };
        }

        private static string ConvertHttpPostedFileBaseToString(HttpPostedFileBase httpPostedFile)
        {
            byte[] imageArray = new byte[httpPostedFile.ContentLength];
            httpPostedFile.InputStream.Read(imageArray, 0, httpPostedFile.ContentLength);

            return Convert.ToBase64String(imageArray);
        }
    }
}