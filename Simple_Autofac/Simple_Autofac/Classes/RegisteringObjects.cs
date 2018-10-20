using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Autofac
{
    public class RegisteringObjects : IRegisteringObjects
    {
        public IList<Container> RegisteredObjects;

        public RegisteringObjects()
        {
            this.RegisteredObjects = new List<Container>();
        }


        //// Add new container in list
        public void RegisterContainer(Container container)
        {
            // TO DO: Check, if implement type is not an interface
            RegisteredObjects.Add(container);
        }


        //// For implement update
        public void UpdateContainer(Type type, Container container)
        {
            foreach (var item in RegisteredObjects)
            {
                if (item.ToImplement == container.ToImplement)
                {
                    item.ToResolve.Add(type);
                }
            }
        }


        //// For lifeCycle update
        public void UpdateContainer(LifeCycle lifeCycle, Container container)
        {
            foreach (var item in RegisteredObjects)
            {
                if (item.ToImplement == container.ToImplement)
                {
                    item.Existence = lifeCycle;
                }
            }
        }


        //// For getting Registered Objects
        public IList<Container> GetContainer()
        {
            return this.RegisteredObjects;
        }

    }
}
