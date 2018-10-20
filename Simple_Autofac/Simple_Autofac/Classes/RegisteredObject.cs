using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Autofac
{
    public class RegisteredObject : IRegisteredObject
    {
        private IList<Container> RegisteredObjects = new List<Container>();


        public RegisteredObject(IRegisteringObjects _registeringObjects)
        {
            this.RegisteredObjects = _registeringObjects.GetContainer();
        }


        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }


        private IEnumerable<object> ResolveCtorParam(Container cObject)
        {
            var info = cObject.ToImplement.GetConstructors().FirstOrDefault();

            foreach (var parameter in info.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }


        private object ResolveObject(Type toResolve)
        {
            var cObject = FindTypeToResolve(toResolve);

            if (null == cObject)
            {
                throw new Exception($"The type {toResolve.Name} has not been registered");
            }

            return GetInstance(cObject);
        }


        private object GetInstance(Container cObject)
        {
            if (null == cObject.Instance || cObject.Existence == LifeCycle.Transient)
            {
                var parameters = ResolveCtorParam(cObject);
                CreateInstance(cObject.ToImplement, cObject, parameters.ToArray());
            }

            return cObject.Instance;
        }


        private Container FindTypeToResolve(Type type)
        {
            foreach (var item in RegisteredObjects)
            {
                foreach (var resolve in item.ToResolve)
                {
                    if (resolve == type)
                    {
                        return item;
                    }
                }
            }

            return null;
        }


        private void CreateInstance(Type instance, Container container, params object[] tmp)
        {
            InstanceSet(Activator.CreateInstance(instance, tmp), container);
        }


        private void InstanceSet(object instance, Container container)
        {
            foreach (var item in RegisteredObjects)
            {
                if (item.ToImplement == container.ToImplement)
                {
                    item.Instance = instance;
                }
            }
        }


    }
}
