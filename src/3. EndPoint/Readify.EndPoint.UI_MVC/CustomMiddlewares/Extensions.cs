namespace Readify.EndPoint.UI_MVC.CustomMiddlewares;

public static class Extensions
{
    public static IApplicationBuilder CustomExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }

}