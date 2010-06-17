using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;

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

  public class Disposables : IDisposable
  {
    private readonly List<IDisposable> myDisposables = new List<IDisposable>();
    private static readonly ILog LOG = LogManager.GetLogger(typeof(Disposables));

    public void Add(IDisposable disp)
    {
      if (disp != null)
      {
        lock (myDisposables)
        {
          myDisposables.Add(disp);
        }
      }
    }

    public void Dispose()
    {
      IDisposable[] disposables;
      lock(myDisposables)
      {        
        disposables = myDisposables.ToArray();
        myDisposables.Clear();
      }

      foreach (var disposable in disposables)
      {
        try
        {
          disposable.Dispose();
        } catch (Exception e)
        {
          LOG.Warn("Failed to dispose " + disposable.GetType(), e);
        }
      }
    }
  }

  public static class DisposablesHelpers
  {
    public static void Add(this Disposables disp, Action init, Action dispose)
    {
      init();
      disp.Add(new DisposableWrapper(()=>dispose()));
    }

    public static void AddEvent<E>(this Disposables disp, E handler, Action<E> subscrbe, Action<E> unsubscribe)
    {
      subscrbe(handler);
      disp.Add(new DisposableWrapper(() => unsubscribe(handler)));
    }

    public static void Subscribe(this Disposables disp, Control control)
    {
      control.Disposed += delegate { disp.Dispose(); };
    }
  }

  public class DisposableWrapper : IDisposable
  {
    private readonly VoidDelegate myDelegate;

    public DisposableWrapper(VoidDelegate myDelegate)
    {
      this.myDelegate = myDelegate;
    }

    public void Dispose()
    {
      myDelegate();
    }
  }
}