using System;
using DSIS.Graph.Entropy;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class ComputeJVREntropyListener<T,Q> : ComputeEntropyListenerBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected override IEntropyEvaluator<Q> GetLoopEntropyEvaluator()
    {
      throw new NotImplementedException();      
    }

    protected override string Suffix
    {
      get { return "JVR"; }
    }
  }
}