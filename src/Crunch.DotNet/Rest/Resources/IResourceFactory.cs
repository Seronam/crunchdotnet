namespace Crunch.DotNet.Rest.Resources
{
    public interface IResourceFactory
    {
        T Create<T>();
    }
}