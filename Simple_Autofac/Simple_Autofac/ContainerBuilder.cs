using System;
using System.Collections.Generic;
using System.Linq;


namespace Simple_Autofac
{
    public class ContainerBuilder : IContainer
    {
        private RegisteredObject RObject;
        private List<Type> resolveObjects = new List<Type>();
        private IList<RegisteredObject> registeredObjects = new List<RegisteredObject>();

        public ContainerBuilder()
        {
            this.RObject = new RegisteredObject();
        }


        public IContainer RegisterType<TImplement>()
        {
            var type = typeof(TImplement);
            this.RObject.SetToImplement(type);

            return this;
        }


        public IContainer As<TTypeToResolve>()
        {
            var type = typeof(TTypeToResolve);
            this.resolveObjects.Add(type);

            return this;
        }


        public void SingleInstance()
        {
            this.RObject.SetExistence(LifeCycle.Singleton);
        }


        public void InstancePerDependency()
        {
            this.RObject.SetExistence(LifeCycle.Transient);
        }


        public void Build()
        {
            this.RObject.SetToResolve(resolveObjects);

            if (null == RObject.ToImplement)
            {
                throw new Exception("Nothing to implement");
            }

            registeredObjects.Add(RObject);
        }


        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }


        public object Resolve(Type toResolve)
        {
            return ResolveObject(toResolve);
        }


        private IEnumerable<object> ResolveCtorParam(RegisteredObject rObject)
        {
            var info = rObject.ToImplement.GetConstructors().First();

            foreach (var parameter in info.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }


        private object ResolveObject(Type toResolve)
        {


            var rObject = registeredObjects.FirstOrDefault(r => r.ToResolve == toResolve);

            if (null == rObject)
            {
                throw new Exception($"The type {toResolve.Name} has not been registered");
            }

            return GetInstance(rObject);
        }


        private object GetInstance(RegisteredObject rObject)
        {
            if (null == rObject.Instance || rObject.Existence == LifeCycle.Transient)
            {
                var parameters = ResolveCtorParam(rObject);
                rObject.CreateInstance(parameters.ToArray());
            }

            return rObject.Instance;
        }




        //public void RegisterType<TTypeToResolve, TImplement>(LifeCycle existence)
        //{
        //    registeredObjects.Add(new RegisteredObject(typeof(TTypeToResolve), typeof(TImplement), existence));
        //}


        //public void RegisterType<TTypeToResolve, TImplement>()
        //{
        //    RegisterType<TTypeToResolve, TImplement>(LifeCycle.Singleton);
        //}

    }
}
