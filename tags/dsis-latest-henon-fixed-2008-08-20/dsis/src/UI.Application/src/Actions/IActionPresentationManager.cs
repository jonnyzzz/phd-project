using System.Collections.Generic;

namespace DSIS.UI.Application.Actions
{
  public interface IActionPresentationManager
  {
    void RegisterAction(IActionDescriptor desc);
    ActionDescriptor RootAction { get; }
    IEnumerable<IActionDescriptor> Children(IActionDescriptor action);
    IActionHandler Handler(IActionDescriptor action);
  }
}