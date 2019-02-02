using Autofac;
using DemoLibrary;
using System.Linq;
using System.Reflection;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            //Create the builder
            var builder = new ContainerBuilder();

            //Register the types associated to the interfaces
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            //Go to the Utilities folder (namespace) register all the classes 
            //and link them to their applicable interfaces
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //return the IoC container
            return builder.Build();
        }
    }
}
