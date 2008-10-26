using DSIS.Core.Ioc.Ex;
using DSIS.Core.System;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using Keys=DSIS.Scheme.Impl.Keys;

namespace DSIS.UI.UI
{
  public class ApplicationDocument : IApplicationDocument
  {
    private readonly IApplicationClass myApplication;
    private readonly string myTitle;
    private readonly Context myContext;

    public ApplicationDocument(string title, Context context, IApplicationClass application)
    {
      myTitle = title;
      myApplication = application;
      myContext = context;
    }

    public ISystemInfo System
    {
      get { return Keys.SystemInfoKey.Get(myContext); }
    }

    public ISystemSpace Space
    {
      get { return Keys.IntegerCoordinateSystemInfo.Get(myContext).SystemSpace; }
    }

    public Context Content
    {
      get { 
        var ctx = new Context(); 
        ctx.AddAll(myContext);
        return ctx; 
      }
    }

    public void ChangeDocument(Context newContext)
    {
      var ctx = new Context();
      ctx.AddAll(newContext);

      AddIfNoteDefined(ctx, newContext, Keys.SystemSpaceKey);
      AddIfNoteDefined(ctx, newContext, Keys.SystemInfoKey);

      var doc = new ApplicationDocument(myTitle, ctx, myApplication);
      myApplication.Document = doc;
    }

    private void AddIfNoteDefined<T>(IWriteOnlyContext ctx, IReadOnlyContext newContext, Key<T> key)
    {
      if (!newContext.ContainsKey(key))
      {
        key.Copy(myContext, ctx);
      }
    }

    public string Title
    {
      get { return myTitle; }
    }
  }
}