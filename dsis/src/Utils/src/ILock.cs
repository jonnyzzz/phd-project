using System;

namespace DSIS.Utils
{
  public interface ILock
  {
    event EventHandler<EventArgs> LockTaken;
    event EventHandler<EventArgs> LockReturned;

    IDisposable TakeLock();

    T IfFree<T>(Func<T> free, Func<T> busy);
  }

  public static class LockHelper
  {
    public static void IfFree(this ILock lck, Action free, Action busy)
    {
      lck.IfFree(() =>
                   {
                     free();
                     return 0;
                   },
                 () =>
                   {
                     busy();
                     return 0;
                   });
    }
  }
}