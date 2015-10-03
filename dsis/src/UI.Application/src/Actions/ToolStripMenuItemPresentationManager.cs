using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation]
  public class ToolStripMenuItemPresentationManager : BuildingActionPresentationManager<ToolStripItem>, IMainMenuFactory
  {
    public ToolStripMenuItemPresentationManager(IActionPresentationManager presentation) : base(presentation)
    {
    }

    protected override IMenuItem<ToolStripItem> CreateItem(IActionDescriptor descriptor, IActionHandler handler, Lazy<Context> context)
    {
      if (descriptor is ActionDescriptor)
        return new ToolStripMenuItemAction((ActionDescriptor) descriptor, handler, context);

      if (descriptor is SeparatorDescriptor)
        return new ToolStripMenuItemSerparator();
      
      return null;
    }

    protected override void SetChildren(IMenuItem<ToolStripItem> node, IEnumerable<IMenuItem<ToolStripItem>> children)
    {
      var map = new List<ToolStripItem>(children.Map(x => x.MainMenu));
      ((ToolStripDropDownItem)node).DropDownItems.AddRange(map.ToArray());
    }

    public void SetMenu(IActionDescriptor descr, MenuStrip strip, Lazy<Context> ctx)
    {
      var menuHandler = BuildMenu(descr, ctx);
      strip.Items.Clear();

      foreach (var child in menuHandler.Children)
      {
        child.With(x =>
                     {
                       strip.MenuActivate += delegate { x.Update(); };
                       strip.Items.Add(x.MainMenu);
                     });
      }
    }
  }
}