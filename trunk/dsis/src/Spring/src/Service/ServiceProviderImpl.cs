using System;
using DSIS.Spring.Attributes;
using Spring.Context;

namespace DSIS.Spring.Service
{
  [UsedBySpring, SpringBean]
  public class ServiceProviderImpl : IServiceProvider, IApplicationContextAware
  {
    public T GetService<T>()
    {
      var names = ApplicationContext.GetObjectNamesForType(typeof(T));
      if (names.Length != 1)
      {
        throw new ArgumentException(typeof(T).FullName + " class should be defined only once");
      }

      return GetComponent<T>(names[0]);
    }

    private T GetComponent<T>(string name)
    {
      return (T) ApplicationContext.GetObject(name, typeof (T));
    }


    public IApplicationContext ApplicationContext { get; set; }
  }
}