namespace PipelineDemo.ConsoleApp
{
    using PipelineDemo.Core;
    using System;
    using System.Threading.Tasks;

    public class ResponseFilter : Operation<HttpContext>
    {
        protected override Task Execute(HttpContext context, Func<HttpContext, Task> next)
        {
            Console.WriteLine($"Here is the result :) => {context.Response}");
            return Task.CompletedTask;
        }
    }
}
