namespace DSIS.Utils
{
  public class NoSafe : ISafe
  {
    public static readonly ISafe Instance = new NoSafe();

    public void Safe(VoidDelegate action)
    {
      action();
    }

    public void SafeIgnore(VoidDelegate action)
    {
      action();
    }

    public void Safe<T>(T obj, DAction<T> action)
    {
      action(obj);
    }

    public void SafeIgnore<T>(T obj, DAction<T> action)
    {
      action(obj);
    }

    public T Safe<T>(TDelegate<T> del)
    {
      return del();
    }
  }
}