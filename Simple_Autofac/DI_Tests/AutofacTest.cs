using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple_Autofac;

namespace DI_Tests
{
    public class MainClass : IResolve { }

    public interface IResolve { }


    public class ConstructorClass : IConstructorResolve
    {
        public ConstructorClass(IResolve resolve)
        {

        }
    }

    public interface IConstructorResolve { }




    [TestClass]
    public class AutofacTest
    {
        [TestMethod]
        public void ResolveContainerTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainClass>().As<IResolve>();
            builder.Build();

            var instance = builder.Resolve<IResolve>();
            Assert.IsInstanceOfType(instance, typeof(MainClass));
        }
    }
}
