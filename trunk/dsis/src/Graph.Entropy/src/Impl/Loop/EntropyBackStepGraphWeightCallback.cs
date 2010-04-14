using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  [Obsolete]
  public class EntropyBackStepGraphWeightCallback<Q, N> : EntropyGraphWeightCallback<Q, N>
    where Q : ICellCoordinate
    where N : class, INode<Q>
  {
    private readonly ICellCoordinateSystem<Q> mySystem;

    public EntropyBackStepGraphWeightCallback(ICellCoordinateSystem<Q> system, IEntropyLoopWeightCallback loopWeight) : base(loopWeight, system)
    {
      mySystem = system;
    }

    public EntropyBackStepGraphWeightCallback<Q,N> BackStep(long[] power)
    {
      ICellCoordinateSystemProjector<Q> projector = mySystem.Project(power);

      if (projector == null)
        return null;
      
      var instance = new EntropyBackStepGraphWeightCallback<Q,N>(projector.ToSystem, myWeight);

      foreach (Pair<NodePair<Q>, double> pair in Weights)
      {
        Q pFrom = projector.Project(pair.First.From);
        Q pTo = projector.Project(pair.First.To);

        if (projector.ToSystem.IsNull(pFrom))
          continue;
        if (projector.ToSystem.IsNull(pTo))
          continue;

        instance.Add(pFrom, pTo, pair.Second);
      }
      instance.Norm = Norm;
      return instance;
    }
  }
}