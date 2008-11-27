namespace DSIS.Core.Util
{
  public sealed class EmptyArray<T>
  {
    public static readonly T[] Instance = new T[0];
  }
}