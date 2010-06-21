using System;

namespace DSIS.Utils
{
  /// <summary>
  /// Dispose may be called in any thread
  /// </summary>
  public abstract class WaitDisposeBase : IDisposable
  {
    private readonly Update myWaits = new Update();
    private bool myIsDisposed;

    protected WaitDisposeBase()
    {
      myWaits.LockReturned += delegate { DoDisposeInternal(); };
    }

    public IDisposable WaitDispose()
    {
      return myWaits.TakeLock();
    }

    protected abstract void DoDispose();

    private void DoDisposeInternal()
    {
      lock (myWaits)
      {
        if (!myIsDisposed)
        {
          myIsDisposed = true;
          DoDispose();
        }
      }
    }

    public void Dispose()
    {
      myWaits.IfFree(DoDisposeInternal, () => { });
    }
  }
}