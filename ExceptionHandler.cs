using System.Net;

namespace FinalMockProject.MiddleWare
{
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> logger;
        private readonly RequestDelegate next;

        public ExceptionHandler(ILogger<ExceptionHandler> logger, RequestDelegate next)

        {
            this.logger = logger;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);


            }
            catch (Exception ex)
            {
                var errorID = Guid.NewGuid();
                //Log the exception
                logger.LogError(ex, $"{errorID}:{ex.Message}");
                //Return a custom error response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var error = new
                {
                    Id = errorID,
                    ErrorMessage = "Something went wrong",
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}

