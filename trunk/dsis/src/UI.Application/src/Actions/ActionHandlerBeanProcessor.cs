using DSIS.Core.Ioc;
using DSIS.Spring.Attributes;

namespace DSIS.UI.Application.Actions
{
  [SpringBean, ComponentImplementation(Startable = true), ComponentInterface]
  public class ActionHandlerBeanProcessor : IStartableComponent
  {
    private readonly IComponentContainer myContainer;
    private readonly IActionPresentationManager myMan;

    public ActionHandlerBeanProcessor(IComponentContainer container, IActionPresentationManager man)
    {
      myContainer = container;
      myMan = man;
    }

    public void Start()
    {
      var c = myContainer.SubContainer<ComponentInterfaceAttribute, ComponentCollectionAttribute, ActionHandlerAttribute>();
      var s = c.GetComponent<IComponentContainerServices>();

      foreach (var handler in s.GetServices<IActionHandler>())
      {
        myMan.RegisterHandler(handler);
      }

      s.RegisterServiceAdded<IActionHandler>(x => myMan.RegisterHandler(x));
    }
  }
}