using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpEntropyValueAction : DumpEntropyAction
  {
    protected override void Dump<Q>(Logger logger, IGraphMeasure<Q> measure)
    {
      logger.Write("Entropy: {0}", measure.GetEntropy());
    }
  }
}