using System.Collections.Generic;

namespace Crunch.DotNet.Rest
{
    public interface IResource<T> : IReadOnlyResource<T>
    {
        void AddOrUpdate(T item);
    }

    public interface IReadOnlyResource<out T>
    {
        IReadOnlyList<T> Get();
    }

    public interface ISingleResource<T> : IReadOnlySingleResource<T>
    {
        void AddOrUpdate(T item);
    }

    public interface IReadOnlySingleResource<out T>
    {
        T Get();
    }
}