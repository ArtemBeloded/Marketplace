using AutoMapper;
using Marketplace.DAL.Models;
using System;
using System.Web;

namespace Marketplace.Infrastructure.Infrastructure
{
	public class AutoMapperConfig
	{
		public static MapperConfiguration ConfigureContainer(Action<IMapperConfigurationExpression> mapperConfiguration = null)
		{
			return new MapperConfiguration(cfg =>
			{
				mapperConfiguration.Invoke(cfg); 
			});
		}
	}
}
