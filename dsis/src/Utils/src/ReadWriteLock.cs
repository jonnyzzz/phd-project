using System;
using System.Threading;

namespace DSIS.Utils
{
  public class ReadWriteLock
  {
    private readonly object myLOCK = new object();
    private readonly AutoResetEvent myLockLeft = new AutoResetEvent(false);

    private int myReaders;
    private bool myUnderWriteLock;

    public IDisposable ReadLock()
    {
      while (true)
      {
        lock (myLOCK)
        {
          if (!myUnderWriteLock)
          {
            myReaders++;
            return new DisposableWrapper(FreeReadLock);
          }
        }
        myLockLeft.WaitOne();
      }
    }

    private void FreeReadLock()
    {
      lock (myLOCK)
      {
        myReaders--;
        myLockLeft.Set();
      }
    }

    public IDisposable WriteLock()
    {
      while (true)
      {
        lock (myLOCK)
        {
          if (myReaders == 0 || !myUnderWriteLock)
          {
            myUnderWriteLock = true;
            return new DisposableWrapper(FreeWriteLock);
          }
        }
        myLockLeft.WaitOne();
      }
    }

    private void FreeWriteLock()
    {
      lock (myLOCK)
      {
        myUnderWriteLock = false;
        myLockLeft.Set();
      }
    }
  }
}