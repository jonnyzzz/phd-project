using System;
using System.Threading;

namespace DSIS.Utils
{
  public class Lock : ILock
  {
    private readonly object myLock = new object();
    private readonly AutoResetEvent myLockLeft = new AutoResetEvent(false);
    private volatile bool myIsTaken;

    public event EventHandler<EventArgs> LockTaken;
    public event EventHandler<EventArgs> LockReturned;

    public IDisposable TakeLock()
    {
      while (true)
      {
        lock (myLock)
        {
          if (!myIsTaken)
          {
            myIsTaken = true;
            break;
          }
        }
        myLockLeft.WaitOne();
      }
      LockTaken.Fire(this, EventArgs.Empty);
      return new DisposableWrapper(FreeLock);
    }

    /// <summary>
    /// Checks lock state at the moment and call one of the delegates
    /// </summary>
    /// <param name="free">If lock is free</param>
    /// <param name="busy">If lock is taken</param>
    /// <returns></returns>
    public T IfFree<T>(Func<T> free, Func<T> busy)
    {
      bool isTaken;
      lock (myLock)
      {
        isTaken = myIsTaken;
      }

      return isTaken ? busy() : free();
    }

    private void FreeLock()
    {
      lock (myLock)
      {
        myIsTaken = false;
        myLockLeft.Set();
      }
      LockReturned.Fire(this, EventArgs.Empty);
    }
  }
}