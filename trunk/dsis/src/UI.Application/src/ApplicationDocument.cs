using DSIS.Core.System;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;
using log4net;

namespace DSIS.UI.Application
{
  public class ApplicationDocument : IApplicationDocument
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(ApplicationDocument));

    private readonly string myTitle;
    private readonly Context myContext;

    public ApplicationDocument(string title, Context context)
    {
      myTitle = title;
      myContext = context;

      if (LOG.IsDebugEnabled)
      {
        LOG.Debug("New document: " + context);
      }
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
      get
      {
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