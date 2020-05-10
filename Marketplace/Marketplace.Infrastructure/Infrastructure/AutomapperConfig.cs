using AutoMapper;
using System;

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
