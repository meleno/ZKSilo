using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.PushSDK.Filters
{
	public class IDValidationFilter : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ActionArguments.TryGetValue("SN", out object value))
			{
				context.Result = new ForbidResult();
			}
		}
	}
}
