namespace PipelineDemo.ConsoleApp
{
    using PipelineDemo.Core;
    using System;
    using System.Threading.Tasks;

    public class ReverseStringFilter : Operation<HttpContext>
    {
        protected override async Task Execute(HttpContext context, Func<HttpContext, Task> next)
        {
            char[] array = context.Response.ToCharArray();
            Array.Reverse(array);
            context.Response = new string(array);

            await next(context);
        }
    }
}
