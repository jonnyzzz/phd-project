using System.Collections.Generic;

namespace DSIS.UI.Application.Actions
{
  public interface IActionPresentationManager
  {
    void RegisterAction(ActionDescriptor desc);
    ActionDescriptor RootAction { get; }
    IEnumerable<ActionDescriptor> Children(ActionDescriptor action);
    IActionHandler Handler(ActionDescriptor action);
  }
}