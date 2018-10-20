using System;
using System.Collections.Generic;

namespace Simple_Autofac
{
    public interface IRegisteringObjects
    {
        void RegisterContainer(Container container);
        void UpdateContainer(LifeCycle lifeCycle, Container container);
        void UpdateContainer(Type type, Container container);
        IList<Container> GetContainer();
    }
}