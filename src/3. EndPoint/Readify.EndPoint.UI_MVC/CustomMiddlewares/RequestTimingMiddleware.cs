using System.Diagnostics;

namespace Readify.EndPoint.UI_MVC.CustomMiddlewares;

public class RequestTimingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        await next(context);

        stopwatch.Stop();
        var elapsedMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Request [{context.Request.Method}] {context.Request.Path} took {elapsedMs} ms");
    }

}