using System;
using DSIS.Core.Ioc;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;
using DSIS.Utils;
using log4net;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class DocumentManager : IDocumentManager
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (DocumentManager));

    [Autowire]
    private IApplicationClass myApplication { get; set; }

    [Autowire]
    private IInvocator myInvocator { get; set; }

    private readonly ILock myOperationLock = new Lock();

    public DocumentManager()
    {
      myOperationLock.LockReturned += (x, a) => myInvocator.InvokeOrQueue("Unlocked", ()=>OperationTaken.Fire(x, new OperationEventArgs(false)));
      myOperationLock.LockTaken += (x, a) => myInvocator.InvokeOrQueue("Locked", ()=>OperationTaken.Fire(x, new OperationEventArgs(true)));
    }

    public IContextOperation GetContextWriteOperation()
    {
      var cookie = myOperationLock.TakeLock();
      return new ContextWrite(myApplication, myInvocator, cookie);
    }

    public event EventHandler<OperationEventArgs> OperationTaken;

    private class ContextWrite : WaitDisposeBase, IContextOperation
    {
      private readonly IApplicationClass myApplication;
      private readonly IInvocator myInvocator;
      private readonly IDisposable myDispose;
      private bool myIsDisposed;

      public ContextWrite(IApplicationClass application, IInvocator invocator, IDisposable dispose)
      {
        myApplication = application;
        myDispose = dispose;
        myInvocator = invocator;
      }

      private void AssertDisposed()
      {
        if (myIsDisposed)
        {
          LOG.ErrorFormat("Disposed object call: {0}", Environment.StackTrace);          
        }
      }

      public void ChangeDocument(Context newContext)
      {
        AssertDisposed();

        myInvocator.InvokeOrQueue(
          "Create new document",
          delegate
            {
              var ctx = UpdateContext(myApplication.Document.Content, newContext);

              var doc = new ApplicationDocument(myApplication.Document.Title, ctx);
              myApplication.Document = doc;
            });
      }

      public Context UpdateContext(IReadOnlyContext currentContext, Context newContext)
      {
        AssertDisposed();

        var ctx = new Context();
        ctx.AddAll(newContext);

        AddIfNoteDefined(currentContext, ctx, newContext, Keys.SystemSpaceKey);
        AddIfNoteDefined(currentContext, ctx, newContext, Keys.SystemInfoKey);
        return ctx;
      }

      private static void AddIfNoteDefined<T>(IReadOnlyContext document, IWriteOnlyContext ctx,
                                              IReadOnlyContext newContext, Key<T> key)
      {
        if (!newContext.ContainsKey(key))
        {
          key.Copy(document, ctx);
        }
      }

      protected override void DoDispose()
      {
        AssertDisposed();
        myIsDisposed = true;
        myDispose.Dispose();
      }
    }
  }
}