using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions
{
  public abstract class BuildingActionPresentationManager<T>
    where T : class 
  {
    private readonly IActionPresentationManager myPresentation;

    protected BuildingActionPresentationManager(IActionPresentationManager presentation)
    {
      myPresentation = presentation;
    }

    protected abstract T CreateItem(IActionDescriptor descriptor, IActionHandler handler);

    protected abstract void SetChildren(T node, IEnumerable<T> children);
    
    public T BuildMenu(IActionDescriptor action)
    {
      var item = CreateItem(action, myPresentation.Handler(action));
      var notNull = new List<T>(myPresentation.Children(action).MapNotNull(x => BuildMenu(x)));
      if (notNull.Count > 0)
      {
        SetChildren( item, notNull);
      }
      return item;
    }
  }
}