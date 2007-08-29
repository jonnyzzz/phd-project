using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class StraitArcDirection<T> : ArcDirection<T>
    where T : ICellCoordinate<T>
  {
    public StraitArcDirection(HashHolder<T> hash) : base(hash)
    {
    }

    protected override T GetStart(JVRPair<T> pair)
    {
      return pair.From;
    }
  }
}