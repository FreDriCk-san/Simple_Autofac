using System;
using System.Collections.Generic;
using System.Linq;


namespace Simple_Autofac
{
    public class ContainerBuilder : IContainer, IRegisteredObject
    {
        private IContainer _container;
        private IRegisteredObject _registeredObject;

        public ContainerBuilder()
        {
            this._container = new Container();
        }

        public IContainer As<TToResolve>()
        {
            return _container.As<TToResolve>();
        }

        public void AsSelf()
        {
            _container.AsSelf();
        }

        public IRegisteredObject Build()
        {
            return this._registeredObject = _container.Build();
        }

        public void InstancePerDependency()
        {
            _container.InstancePerDependency();
        }

        public IContainer RegisterType<TToImplement>()
        {
            return _container.RegisterType<TToImplement>();
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return _registeredObject.Resolve<TTypeToResolve>();
        }

        public void SingleInstance()
        {
            _container.SingleInstance();
        }
    }
}
