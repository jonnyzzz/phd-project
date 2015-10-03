using System;
using System.Threading;

namespace DSIS.Utils
{
  public class MutexCookie : IDisposable
  {
    private readonly Mutex myMutex;

    public MutexCookie(Mutex mutex)
    {
      myMutex = mutex;
      myMutex.WaitOne();
    }

    void IDisposable.Dispose()
    {
      myMutex.ReleaseMutex();
    }
  }

  public class TryMutexCookie : IDisposable
  {
    private readonly Mutex myMutex;
    public readonly bool IsUnderMutex;

    public TryMutexCookie(Mutex mutex)
    {
      myMutex = mutex;

      IsUnderMutex = mutex.WaitOne(0, false);
    }

    void IDisposable.Dispose()
    {
      if (IsUnderMutex)
      {
        myMutex.ReleaseMutex();
      }
    }
  }
}