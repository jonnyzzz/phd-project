using DSIS.Core.System;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  public class ApplicationDocument : IApplicationDocument
  {
    private readonly IApplicationClass myApplication;
    private readonly IInvocator myInvocator;
    private readonly string myTitle;
    private readonly Context myContext;

    public ApplicationDocument(string title, Context context, IApplicationClass application, IInvocator invocator)
    {
      myTitle = title;
      myApplication = application;
      myInvocator = invocator;
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
      get
      {
        var ctx = new Context();
        ctx.AddAll(myContext);
        return ctx;
      }
    }

    public void ChangeDocument(Context newContext)
    {
      myInvocator.InvokeOrQueue(
        "Create new document",
        delegate
          {
            var ctx = new Context();
            ctx.AddAll(newContext);

            AddIfNoteDefined(ctx, newContext, Keys.SystemSpaceKey);
            AddIfNoteDefined(ctx, newContext, Keys.SystemInfoKey);

            var doc = new ApplicationDocument(myTitle, ctx, myApplication, myInvocator);
            myApplication.Document = doc;
          });
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