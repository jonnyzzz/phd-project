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

  public static class MutexCookieUtil
  {
    public static IDisposable Lock(this Mutex cookie)
    {
      return new MutexCookie(cookie);
    }
  }
}