using DependencyInjection.Interface;

namespace DependencyInjection.Implement;

public class ServiceCollection
{
    private readonly Dictionary<Type, Type> _serviceMappings;

    public ServiceCollection()
    {
        _serviceMappings = new Dictionary<Type, Type>();
    }
    
    public void AddScoped<TService, TImplementation>()
    {
        _serviceMappings[typeof(TService)] = typeof(TImplementation);
    }
    
    public void AddSingleton<TService, TImplementation>()
    {
        _serviceMappings[typeof(TService)] = typeof(TImplementation);
    }

    public void AddTransient<TService, TImplementation>()
    {
        _serviceMappings[typeof(TService)] = typeof(TImplementation);
    }
    
    public IServiceScope BuildServiceProvider()
    {
        var scopedServices = new Dictionary<Type, object>();
        foreach (var serviceMapping in _serviceMappings)
        {
            var serviceType = serviceMapping.Key;
            var implementationType = serviceMapping.Value;
            var serviceInstance = Activator.CreateInstance(implementationType);
            scopedServices[serviceType] = serviceInstance!;
        }
        return new ServiceScope(scopedServices);
    }
}