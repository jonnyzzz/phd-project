using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Util
{
  public class PairBase<T>
    where T : ICellCoordinate<T>
  {
    public readonly T To;
    public readonly T From;

    public PairBase(T from, T to)
    {
      To = to;
      From = from;
    }
  }
}