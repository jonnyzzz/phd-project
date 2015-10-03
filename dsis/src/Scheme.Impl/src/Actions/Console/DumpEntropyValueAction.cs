using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpEntropyValueAction : DumpEntropyAction
  {
    private readonly string myPrefix;


    public DumpEntropyValueAction() : this(string.Empty)
    {
    }

    public DumpEntropyValueAction(string prefix)
    {
      myPrefix = prefix;
    }

    protected override void Dump<Q>(Logger logger, IGraphMeasure<Q> measure)
    {
      logger.Write("Entropy[{1}]: {0}", measure.GetEntropy(), myPrefix);
    }
  }
}