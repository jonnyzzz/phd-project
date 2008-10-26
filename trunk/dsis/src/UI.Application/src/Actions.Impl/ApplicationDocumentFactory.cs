using System;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Actions.Impl
{
  [ComponentImplementation]
  public class ApplicationDocumentFactory : IApplicationDocumentFactory
  {
    private readonly IDocumentContextFill[] myFill;

    public ApplicationDocumentFactory(IDocumentContextFill[] fill)
    {
      myFill = fill;
    }

    public IApplicationDocument CreateNewDocument(string title, ISystemInfo info, ISystemSpace space)
    {
      var ctx = new Context();
      Keys.SystemInfoKey.Set(ctx, info);
      Keys.SystemSpaceKey.Set(ctx, space);

      Array.Sort(myFill, (a,b) => a.Order.CompareTo(b.Order));
      foreach (var fill in myFill)
      {
        fill.FillContext(ctx, ctx);
      }
      
      return new ApplicationDocument(title, ctx);
    }
  }
}