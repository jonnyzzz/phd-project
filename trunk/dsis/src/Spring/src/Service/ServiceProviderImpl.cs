using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Utils;

namespace DSIS.Spring.Service
{
  public interface IServiceProviderEx
  {
    bool GetService<T>(out T obj);

    IEnumerable<T> GetServices<T>();
  }

  [UsedBySpring]
  public class ServiceProviderImpl : IServiceProvider
  {
    private readonly List<IServiceProviderEx> myProviders = new List<IServiceProviderEx>();

    public T GetService<T>()
    {
      foreach (var ex in myProviders)
      {
        T obj;
        if (ex.GetService(out obj))
          return obj;
      }
      throw new Exception("Failed to get object of type " + typeof(T).AssemblyQualifiedName);      
    }

    public IEnumerable<T> GetServices<T>()
    {
      return myProviders.ConvertAll(x => x.GetServices<T>()).SelectMany(c => c);
    }

    public void RegisterProvider(IServiceProviderEx prov)
    {
      myProviders.Add(prov);
    }
  }
}