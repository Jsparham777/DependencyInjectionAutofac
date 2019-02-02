using Autofac;
using System;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Create the IoC container
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                //Create a new instance of Application and run it
                var app = scope.Resolve<IApplication>(); ;
                app.Run();
            }

            Console.ReadLine();
        }
    }
}
