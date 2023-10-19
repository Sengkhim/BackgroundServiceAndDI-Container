namespace DependencyInjection.Interface;

public interface IServiceScope : IDisposable 
{
    object GetService(Type serviceType);
}