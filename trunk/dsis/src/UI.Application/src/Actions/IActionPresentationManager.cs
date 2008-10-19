using System.Collections.Generic;
using DSIS.Core.Ioc;

namespace DSIS.UI.Application.Actions
{
  [ComponentInterface]
  public interface IActionPresentationManager
  {
    void RegisterAction(IActionDescriptor desc);
    ActionDescriptor RootAction { get; }
    IEnumerable<IActionDescriptor> Children(IActionDescriptor action);
    IActionHandler Handler(IActionDescriptor action);
    void RegisterHandler(IActionHandler handler);

    void AddActionDescriptor(string actionId, string parentActionId, string title, string description, string ancor);
  }
}