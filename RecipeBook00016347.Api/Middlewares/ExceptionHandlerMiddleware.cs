using RecipeBook00016347.Api.Helpers;
using RecipeBook00016347.Service.Exceptions;

namespace RecipeBook00016347.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (RecipeBookException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = exception.StatusCode,
                Message = exception.Message
            });
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = 500,
                Message = exception.Message
            });
        }
    }
}
