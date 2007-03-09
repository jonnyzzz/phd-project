/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

namespace DSIS.Core.Util
{
  public struct Pair<TK, TV>
  {
    public readonly TK First;
    public readonly TV Second;

    public Pair(TK first, TV second)
    {
      First = first;
      Second = second;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Pair<TK, TV>)) return false;
      Pair<TK, TV> pair = (Pair<TK, TV>) obj;
      return Equals(First, pair.First) && Equals(Second, pair.Second);
    }

    public override int GetHashCode()
    {
      return (First != null ? First.GetHashCode() : 0) +
             29*(Second != null ? Second.GetHashCode() : 11);
    }

    private static string SafeToString<T>(T t)
    {
      if (t != null)
      {
        return t.ToString();
      }
      return "[Null]";
    }

    public override string ToString()
    {
      return "Pair" + "First: " + SafeToString(First) + " Second: " + SafeToString(Second);
    }
  }
}