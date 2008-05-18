namespace DSIS.Utils
{
  public interface ISafe
  {4
    void Safe(VoidDelegate action);
    void SafeIgnore(VoidDelegate action);

    void Safe<T>(T obj, DAction<T> action);
    void SafeIgnore<T>(T obj, DAction<T> action);
  }
}