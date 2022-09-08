using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Product.Json.Api.Middleware
{
	public class ErrorMiddleware
	{
		private readonly RequestDelegate next;

		public ErrorMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task Invoke(HttpContext context, ILogger<ErrorMiddleware> logger)
		{
			try
			{			
				await next(context);
			}
			catch (Exception e)
			{
				logger.LogError(e.Message, e);
				//context.Response.StatusCode = 401;
				//context.Response.Headers.Add("WWW-Authenticate",
				//	new[] { "Basic" });
			}
		}
	}
}
