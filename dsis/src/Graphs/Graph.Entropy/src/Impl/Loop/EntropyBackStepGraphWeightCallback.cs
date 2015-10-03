using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  [Obsolete]
  public class EntropyBackStepGraphWeightCallback<Q> : EntropyGraphWeightCallback<Q>
    where Q : ICellCoordinate
  {
    private readonly ICellCoordinateSystem<Q> mySystem;

    public EntropyBackStepGraphWeightCallback(ICellCoordinateSystem<Q> system, IEntropyLoopWeightCallback loopWeight) : base(loopWeight, system)
    {
      mySystem = system;
    }

    public EntropyBackStepGraphWeightCallback<Q> BackStep(long[] power)
    {
      ICellCoordinateSystemProjector<Q> projector = mySystem.Project(power);

      if (projector == null)
        return null;
      
      EntropyBackStepGraphWeightCallback<Q> instance = new EntropyBackStepGraphWeightCallback<Q>(projector.ToSystem, myWeight);

      foreach (Pair<NodePair<Q>, double> pair in Weights)
      {
        Q pFrom = projector.Project(pair.First.From);
        Q pTo = projector.Project(pair.First.To);

        if (pFrom != null && pTo != null)
        {
          instance.Add(pFrom, pTo, pair.Second);
        }
      }
      instance.Norm = Norm;
      return instance;
    }
  }
}