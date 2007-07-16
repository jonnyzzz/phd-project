using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  public class EntropyBackStepGraphWeightCallback<Q> : EntropyGraphWeightCallback<Q>
    where Q : ICellCoordinate<Q>
  {
    private readonly ICellCoordinateSystem<Q> mySystem;

    public EntropyBackStepGraphWeightCallback(ICellCoordinateSystem<Q> system)
    {
      mySystem = system;
    }

    public EntropyBackStepGraphWeightCallback<Q> BackStep(long[] power)
    {
      ICellCoordinateSystemProjector<Q> projector = mySystem.Project(power);

      if (projector == null)
        return null;

      EntropyBackStepGraphWeightCallback<Q> instance = new EntropyBackStepGraphWeightCallback<Q>(projector.ToSystem);

      double mySum = 0;
      foreach (Pair<NodePair<Q>, double> pair in Weights)
      {
        Q pFrom = projector.Project(pair.First.From);
        Q pTo = projector.Project(pair.First.To);

        if (pFrom != null && pTo != null)
        {
          mySum += pair.Second;
          instance.Add(pFrom, pTo, pair.Second);
        }
      }
      instance.LoopsCount = mySum;
      return instance;
    }
  }
}