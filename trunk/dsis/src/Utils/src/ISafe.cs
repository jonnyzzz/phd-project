namespace DSIS.Utils
{
  public interface ISafe
  {
    void Safe(VoidDelegate action);
    void SafeIgnore(VoidDelegate action);

    void Safe<T>(T obj, DAction<T> action);
    void SafeIgnore<T>(T obj, DAction<T> action);

    T Safe<T>(TDelegate<T> del, T def);
  }
}