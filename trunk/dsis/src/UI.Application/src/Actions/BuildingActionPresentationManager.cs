using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions
{
  public abstract class BuildingActionPresentationManager<T>
  {
    private readonly IActionPresentationManager myPresentation;

    protected BuildingActionPresentationManager(IActionPresentationManager presentation)
    {
      myPresentation = presentation;
    }

    protected abstract T CreateItem(ActionDescriptor descriptor, IActionHandler handler);

    protected abstract void SetChildren(T node, IEnumerable<T> children);
    
    public T BuildMenu(ActionDescriptor action)
    {
      var item = CreateItem(action, myPresentation.Handler(action));
      SetChildren( item, myPresentation.Children(action).Map(x => BuildMenu(x)));
      return item;
    }
  }
}