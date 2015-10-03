using System.Collections.Generic;
using DSIS.Scheme.Ctx;
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

    protected abstract IMenuItem<T> CreateItem(IActionDescriptor descriptor, IActionHandler handler, Lazy<Context> context);

    protected abstract void SetChildren(IMenuItem<T> node, IEnumerable<IMenuItem<T>> children);
    
    public IMenuItem<T> BuildMenu(IActionDescriptor action, Lazy<Context> context)
    {
      var item = CreateItem(action, myPresentation.Handler(action), context);
      var notNull = new List<IMenuItem<T>>(myPresentation.Children(action).MapNotNull(x => BuildMenu(x, context)));
      if (notNull.Count > 0)
      {
        SetChildren( item, notNull);
      }
      return item;
    }
  }
}