namespace DSIS.Utils
{
  public delegate void VoidDelegate();

  public delegate void DAction<T>(T obj);

  public delegate T TDelegate<T>();

  public delegate T Lazy<T>();

  public delegate void Zip<T, Q>(T t, Q q);

  public delegate void Action<A1, A2>(A1 a, A2 b);
}
