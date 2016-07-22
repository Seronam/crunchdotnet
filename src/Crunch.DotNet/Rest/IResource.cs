using System.Collections.Generic;

namespace Crunch.DotNet.Rest
{
    public interface IResource<T> : IReadOnlyResource<T> where T : class
    {
        T AddOrUpdate(T item);
    }

    public interface IReadOnlyResource<out T> where T : class
    {
        IReadOnlyList<T> Get();
    }

    public interface IReadOnlySingleResource<out T> where T : class
    {
        T Get();
    }
}