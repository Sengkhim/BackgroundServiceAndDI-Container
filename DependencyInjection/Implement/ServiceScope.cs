using DependencyInjection.Interface;

namespace DependencyInjection.Implement;

public class ServiceScope : IServiceScope 
{
    private readonly Dictionary<Type, object> _scopedServices;

    public ServiceScope(Dictionary<Type, object> scopedServices)
    {
        _scopedServices = scopedServices;
    }
    
    public object GetService(Type serviceType)
    {
        _scopedServices.TryGetValue(serviceType, out var service);
        return service!;
    }
    
    public void Dispose()
    {
        // Dispose any disposable services if needed.
        foreach (var service in _scopedServices.Values)
            if (service is IDisposable disposableService)
                disposableService.Dispose();
    }
}