namespace DSIS.Utils
{
  public delegate void VoidDelegate();

  public delegate T TDelegate<T>();

  public delegate T Lazy<T>();

  public delegate void Zip<T, Q>(T t, Q q);

  public delegate R Merge<T, Q, R>(T t, Q q);
}
