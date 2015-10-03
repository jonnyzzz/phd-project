using System.Collections.Generic;
using EugenePetrenko.Shared.Core.Ioc;
using EugenePetrenko.Shared.Core.Ioc.Api;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation]
  public class FakeServiceProvider : IServiceProvider
  {
    private readonly IComponentContainer myContainer;

    public FakeServiceProvider(IComponentContainer container)
    {
      myContainer = container;
    }

    public T GetService<T>()
    {
      return myContainer.GetComponent<T>();
    }

    public IEnumerable<T> GetServices<T>()
    {
      return myContainer.GetComponents<T>();
    }
  }
}