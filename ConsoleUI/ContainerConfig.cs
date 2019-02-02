using Autofac;
using DemoLibrary;
using System.Linq;
using System.Reflection;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        /// <summary>
        /// Container factory (Autofac = Automatic Factory!)
        /// </summary>
        /// <returns></returns>
        public static IContainer Configure()
        {
            //Create the builder
            var builder = new ContainerBuilder();

            //Register the types associated to the interfaces
            builder.RegisterType<Application>().As<IApplication>();
            
            //Easily change out objects by just changing the type, as below
            //builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();

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
