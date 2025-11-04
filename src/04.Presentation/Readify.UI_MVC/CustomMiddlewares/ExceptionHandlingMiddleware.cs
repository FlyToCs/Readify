namespace Readify.UI_MVC.CustomMiddlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                File.AppendAllText("C:\\logs\\error.txt", e.Message);
                context.Response.Redirect("/Home/error");
            }
        }
    }
}
