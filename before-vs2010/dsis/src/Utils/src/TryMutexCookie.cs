using System;
using System.Threading;

namespace DSIS.Utils
{
  public class TryMutexCookie : IDisposable
  {
    private readonly Mutex myMutex;
    public readonly bool IsUnderMutex;

    public TryMutexCookie(Mutex mutex)
    {
      myMutex = mutex;

      IsUnderMutex = mutex.WaitOne(10, false);
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