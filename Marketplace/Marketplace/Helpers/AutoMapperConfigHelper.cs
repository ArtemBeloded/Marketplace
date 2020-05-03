using AutoMapper;
using Marketplace.DAL.Models;
using Marketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace.Helpers
{
    public class AutoMapperConfigHelper
    {
        public static Action<IMapperConfigurationExpression> AddWebMappings()
        {
            return (cfg) =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, Product>().ForMember(x => x.Photo, config =>
                    config.MapFrom((dest) => ConvertHttpPostedFileBaseToString(dest.Photo)));

                cfg.CreateMap<Product, ShowProductVM>()
                .ForMember(t => t.LongDescription, config => config.MapFrom(dest => dest.Description))
                .ForMember(t => t.ShortDescription, config => config.MapFrom(dest => dest.Description.Substring(0, 20)));
                cfg.CreateMap<ShowProductVM, Product>()
                .ForMember(t => t.Description, config => config.MapFrom(dest => dest.LongDescription));

                cfg.CreateMap<Product, UpdateProductVM>();
                cfg.CreateMap<UpdateProductVM, Product>();

                cfg.CreateMap<EditProductVM, Product>()
                .ForMember(x => x.Photo, config =>
                    config.MapFrom((dest) => ConvertHttpPostedFileBaseToString(dest.Photo)));

                cfg.CreateMap<CartLine, CartLineVM>();

                cfg.CreateMap<Product, ProductCartLineVM>();
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