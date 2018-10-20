using System;

namespace Simple_Autofac
{
    public interface IRegisteredObject
    {
        TTypeToResolve Resolve<TTypeToResolve>();
    }
}