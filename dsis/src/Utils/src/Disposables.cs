using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;

namespace DSIS.Utils
{
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
      disp.Add(new DisposableWrapper(() => dispose()));
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
}