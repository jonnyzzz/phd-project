using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation(Startable = true)]
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
      foreach (var handler in c.Start().GetComponents<IActionHandler>())
      {
        myMan.RegisterHandler(handler);
      }
    }
  }
}