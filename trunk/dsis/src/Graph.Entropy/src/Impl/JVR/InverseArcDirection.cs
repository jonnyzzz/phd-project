using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class InverseArcDirection<T> : ArcDirection<T>
    where T : ICellCoordinate<T>
  {
    public InverseArcDirection(HashHolder<T> hash) : base(hash)
    {
    }

    protected override T GetStart(JVRPair<T> pair)
    {
      return pair.To;
    }
  }
}