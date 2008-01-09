using DSIS.Graph.Entropy.Impl.Entropy;
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