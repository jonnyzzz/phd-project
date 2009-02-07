using DSIS.Core.Ioc;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation(Startable = true), ComponentInterface]
  public class ActionHandlerBeanProcessor : IStartableComponent
  {
    private readonly ISubContainerFactory myContainer;
    private readonly IActionPresentationManager myMan;

    public ActionHandlerBeanProcessor(ISubContainerFactory container, IActionPresentationManager man)
    {
      myContainer = container;
      myMan = man;
    }

    public void Start()
    {
      var c = myContainer.SubContainer<ActionHandlerAttribute>();
      c.Start();
      foreach (var handler in c.GetComponents<IActionHandler>())
      {
        myMan.RegisterHandler(handler);
      }
    }
  }
}