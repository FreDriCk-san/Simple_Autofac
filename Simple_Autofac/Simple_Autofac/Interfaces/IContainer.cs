using System;

namespace Simple_Autofac
{
    public interface IContainer
    {
        IContainer RegisterType<TImplement>();
        IContainer As<TTypeToResolve>();
        void SingleInstance();
        void InstancePerDependency();



        //void RegisterType<TTypeToResolve, TImplement>();
        //void RegisterType<TTypeToResolve, TImplement>(LifeCycle existence);
        object Resolve(Type toResolve);
        TTypeToResolve Resolve<TTypeToResolve>();
    }
}