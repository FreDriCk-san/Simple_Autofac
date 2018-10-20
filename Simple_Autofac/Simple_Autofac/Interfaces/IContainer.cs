using System;

namespace Simple_Autofac
{
    public interface IContainer
    {
        IContainer RegisterType<TToImplement>();
        IContainer As<TToResolve>();
        void AsSelf();
        void SingleInstance();
        void InstancePerDependency();
        IRegisteredObject Build();
    }
}