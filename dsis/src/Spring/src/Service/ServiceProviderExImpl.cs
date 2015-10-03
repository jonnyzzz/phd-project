using System;
using System.Collections.Generic;
using DSIS.Spring.Attributes;
using Spring.Context;
using Spring.Objects.Factory.Config;

namespace DSIS.Spring.Service
{
  [UsedBySpring, SpringBean(Priority = int.MinValue)]
  public class ServiceProviderExImpl : IServiceProviderEx, IApplicationContextAware
  {
    public ServiceProviderExImpl(ServiceProviderImpl impl)
    {
        impl.RegisterProvider(this);
    }

    public bool GetService<T>(out T t)
    {
      var names = ApplicationContext.GetObjectNamesForType(typeof (T));
      if (names.Length > 1)
      {
        throw new ArgumentException(typeof (T).FullName + " class should be defined only once");
      }
      if (names.Length == 0)
      {
        t = default(T);
        return false;
      }
      t = GetComponent<T>(names[0]);
      return true;
    }

    public IEnumerable<T> GetServices<T>()
    {
      foreach (string name in ApplicationContext.GetObjectNamesForType(typeof(T)))
      {
        yield return (T) ApplicationContext.GetObject(name);
      }
    }

    private T GetComponent<T>(string name)
    {
      return (T) ApplicationContext.GetObject(name, typeof (T));
    }

    public IApplicationContext ApplicationContext { get; set; }
  }
}