namespace PipelineDemo.ConsoleApp
{
    using PipelineDemo.Core;
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var context = new HttpContext() { Response = "monica" };

            var pipeline = new PipelineBuilder<HttpContext>()
                .Register(new ReverseStringFilter())
                .Register(new UppercaseStringFilter())
                .Register(new ResponseFilter())
                .Build();

            pipeline.Execute(context).Wait();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
