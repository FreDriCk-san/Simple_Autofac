using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Autofac
{
    public class RegisteredObject
    {
        public Type ToImplement { get; private set; }
        public List<Type> ToResolve { get; private set; }
        public LifeCycle Existence { get; private set; }
        public object Instance { get; private set; }


        public RegisteredObject()
        {

        }

        //public RegisteredObject(Type toResolve, Type toImplement, LifeCycle existence)
        //{
        //    this.ToResolve = toResolve;
        //    this.ToImplement = ToImplement;
        //    this.Existence = existence;
        //}

        public void SetToImplement(Type toImplement)
        {
            this.ToImplement = toImplement;
        }

        public void SetToResolve(List<Type> toResolve)
        {
            this.ToResolve = toResolve;
        }

        public void SetExistence(LifeCycle existence)
        {
            this.Existence = existence;
        }


        public void CreateInstance(params object[] tmp)
        {
            this.Instance = Activator.CreateInstance(this.ToImplement, tmp);
        }
    }
}
