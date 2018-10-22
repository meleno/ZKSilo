using Microsoft.Extensions.DependencyInjection;
using WEBAPI.PushSDK.Filters;

namespace WEBAPI.PushSDK.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureFilters(this IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.Filters.Add(typeof(IDValidationFilter));
			});
		}
	}
}
