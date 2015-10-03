using System;

namespace DSIS.Utils
{
  public class Update : ILock
  {
    private int myTakes;
    private readonly object myLock = new object();

    public event EventHandler<EventArgs> LockTaken;
    public event EventHandler<EventArgs> LockReturned;

    public IDisposable TakeLock()
    {
      int take;
      lock (myLock)
      {
        take = ++myTakes;
      }
      if (take == 1)
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
      int taken;
      lock (myLock)
      {
        taken = myTakes;
      }

      return taken > 0 ? busy() : free();
    }

    public void FreeLock()
    {
      int taken;
      lock (myLock)
      {
        taken = --myTakes;
      }
      if (taken == 0)
      {
        LockReturned.Fire(this, EventArgs.Empty);
      }
    }
  }
}