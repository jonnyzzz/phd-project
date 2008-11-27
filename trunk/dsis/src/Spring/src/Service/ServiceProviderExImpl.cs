using System;
using System.Collections.Generic;
using DSIS.Spring.Attributes;

namespace DSIS.Spring.Service
{
  [UsedBySpring, SpringBean(Priority = int.MinValue)]
  public class ServiceProviderExImpl : IServiceProviderEx
  {
    public ServiceProviderExImpl(ServiceProviderImpl impl)
    {
        impl.RegisterProvider(this);
    }

    public bool GetService<T>(out T t)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<T> GetServices<T>()
    {
      throw new NotImplementedException();
    }
  }
}