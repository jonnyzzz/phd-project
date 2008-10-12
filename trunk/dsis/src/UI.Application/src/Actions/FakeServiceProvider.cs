using System.Collections.Generic;
using DSIS.Core.Ioc;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation]
  public class FakeServiceProvider : IServiceProvider
  {
    private readonly IComponentContainer myContainer;
    private readonly IComponentContainerServices myContainerService;

    public FakeServiceProvider(IComponentContainer container, IComponentContainerServices containerService)
    {
      myContainer = container;
      myContainerService = containerService;
    }

    public T GetService<T>()
    {
      return myContainer.GetComponent<T>();
    }

    public IEnumerable<T> GetServices<T>()
    {
      return myContainerService.GetServices<T>();
    }
  }
}