using System;

namespace DSIS.Utils
{
  public interface ISafe
  {
    void Safe(Action action);
    void SafeIgnore(Action action);
    
    void Safe<T>(T obj, Action<T> action);
    void SafeIgnore<T>(T obj, Action<T> action);

    T Safe<T>(Func<T> del, T def);
  }
}