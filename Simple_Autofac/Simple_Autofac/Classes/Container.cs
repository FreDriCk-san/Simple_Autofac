using System;
using System.Collections.Generic;

namespace Simple_Autofac
{
    public class Container : IContainer
    {
        private IRegisteringObjects _registeringObjects;
        private Container container;


        public Type ToImplement { get; set; }
        public List<Type> ToResolve { get; set; }
        public LifeCycle Existence { get; set; }
        public object Instance { get; set; }



        public Container()
        {
            this.ToResolve = new List<Type>();
            this._registeringObjects = new RegisteringObjects();
        }



        public IContainer RegisterType<TToImplement>()
        {
            container = new Container();
            var type = typeof(TToImplement);
            container.ToImplement = type;
            _registeringObjects.RegisterContainer(container);

            return this;
        }



        public IContainer As<TToResolve>()
        {
            var type = typeof(TToResolve);
            _registeringObjects.UpdateContainer(type, container);

            return this;
        }



        public void AsSelf()
        {
            _registeringObjects.UpdateContainer(container.ToImplement, container);
        }



        public void SingleInstance()
        {
            _registeringObjects.UpdateContainer(LifeCycle.Singleton, container);
        }



        public void InstancePerDependency()
        {
            _registeringObjects.UpdateContainer(LifeCycle.Transient, container);
        }



        public IRegisteredObject Build()
        {
            return new RegisteredObject(this._registeringObjects);
        }

    }
}
