using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace VehicleStore.Server.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        //private readonly ILogger _logger;

        //public GlobalExceptionHandlingMiddleware(ILogger logger)
        //{
        //    _logger = logger;
        //}
        public GlobalExceptionHandlingMiddleware()
        {
               
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, e.Message);

                if (e is KeyNotFoundException || e is InvalidOperationException)
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                else
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problemDetails = new()
                {
                    Detail= e.Message,
                    Status = context.Response.StatusCode,
                };
                var json = JsonConvert.SerializeObject(problemDetails);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
