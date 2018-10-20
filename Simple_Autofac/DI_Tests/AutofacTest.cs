using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple_Autofac;

namespace DI_Tests
{

    [TestClass]
    public class AutofacTest
    {
        [TestMethod]
        public void ResolveContainerTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DefaultClass>().As<IDefaultClassA>();
            builder.Build();

            var instance = builder.Resolve<IDefaultClassA>();
            instance.DefaultWriteA();

            Assert.IsInstanceOfType(instance, typeof(DefaultClass));
        }



        [TestMethod]
        public void NotBuildedException()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DefaultClass>().As<IDefaultClassB>();

            Exception exception = null;

            try
            {
                builder.Resolve<IDefaultClassB>();
            }
            catch (Exception except)
            {
                exception = except;
            }

            Assert.IsNotNull(exception);
        }



        [TestMethod]
        public void NotRegisteredException()
        {
            var builder = new ContainerBuilder();
            builder.Build();

            Exception exception = null;

            try
            {
                builder.Resolve<IDefaultClassA>();
            }
            catch (Exception except)
            {
                exception = except;
            }

            Assert.IsNotNull(exception);
        }



        [TestMethod]
        public void ResolveWithConstructorParams()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DefaultClass>().As<IDefaultClassA>();
            builder.RegisterType<ConstructorClass>().As<IConstructorClass>();
            builder.Build();

            var instance = builder.Resolve<IConstructorClass>();
            instance.ConstructorWriteA();

            Assert.IsInstanceOfType(instance, typeof(ConstructorClass));
        }



        [TestMethod]
        public void RegisterAsSelf()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DefaultClass>().AsSelf();
            builder.Build();

            var instance = builder.Resolve<DefaultClass>();
            instance.DefaultWriteA();
            instance.DefaultWriteB();

            Assert.IsInstanceOfType(instance, typeof(DefaultClass));
        }



        [TestMethod]
        public void SetSingletoneByDefault()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DefaultClass>().As<IDefaultClassA>();
            builder.Build();

            var instance = builder.Resolve<IDefaultClassA>();
            instance.DefaultWriteA();

            Assert.AreSame(builder.Resolve<IDefaultClassA>(), instance);
        }



        [TestMethod]
        public void CreateTransientInstance()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DefaultClass>().As<IDefaultClassA>().InstancePerDependency();
            builder.Build();

            var instance = builder.Resolve<IDefaultClassA>();
            instance.DefaultWriteA();

            Assert.AreNotSame(builder.Resolve<IDefaultClassA>(), instance);
        }
    }
}
