using DemoLibrary;

namespace ConsoleUI
{
    public class Application : IApplication
    {
        private readonly IBusinessLogic _businessLogic;
        /// <summary>
        /// When Main() requests an Application object, Autofac will new up the constructor Interface
        /// </summary>
        /// <param name="businessLogic"></param>
        public Application(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public void Run()
        {
            _businessLogic.ProcessData();
        }
    }
}
