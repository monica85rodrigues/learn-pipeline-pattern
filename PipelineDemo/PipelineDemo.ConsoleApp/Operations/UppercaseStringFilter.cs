namespace PipelineDemo.ConsoleApp
{
    using PipelineDemo.Core;
    using System;
    using System.Threading.Tasks;

    public class UppercaseStringFilter : Operation<HttpContext>
    {
        protected override async Task Execute(HttpContext context, Func<HttpContext, Task> next)
        {
            context.Response = context.Response.ToUpperInvariant();
            await next(context);
        }
    }
}
