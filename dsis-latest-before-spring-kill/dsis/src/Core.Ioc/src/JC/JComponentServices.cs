using System;
using System.Collections.Generic;

namespace DSIS.Core.Ioc.JC
{
  [JContainerPredefinedComponent]
  public class JComponentServices : IComponentContainerServices
  {
    private readonly IComponentContainer myContainer;

    public JComponentServices(IComponentContainer container)
    {
      myContainer = container;
    }

    public IEnumerable<T> GetServices<T>()
    {
      return myContainer.GetComponents<T>();
    }

    public void RegisterServiceAdded<T>(Action<T> action)
    {
      throw new System.NotImplementedException();
    }
  }
}