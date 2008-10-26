using DSIS.Core.System;
using DSIS.Scheme.Ctx;
using Keys=DSIS.Scheme.Impl.Keys;

namespace DSIS.UI.UI
{
  public class ApplicationDocument : IApplicationDocument
  {
    private readonly string myTitle;
    private readonly Context myContext;

    public ApplicationDocument(string title, Context context)
    {
      myTitle = title;
      myContext = context;
    }

    public ISystemInfo System
    {
      get { return Keys.SystemInfoKey.Get(myContext); }
    }

    public ISystemSpace Space
    {
      get { return Keys.SystemSpaceKey.Get(myContext); }
    }

    public Context Content
    {
      get { 
        var ctx = new Context(); 
        ctx.AddAll(myContext);
        return ctx; 
      }
    }

    public string Title
    {
      get { return myTitle; }
    }
  }
}