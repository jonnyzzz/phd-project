namespace DSIS.Utils
{
  public sealed class EmptyArray<T>
  {
    public static readonly T[] Instance = new T[0];
  }
}