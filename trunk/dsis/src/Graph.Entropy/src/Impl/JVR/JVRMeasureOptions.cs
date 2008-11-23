using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class JVRMeasureOptions
  {
    public bool IncludeSelfEdge { get; set; }
    public IEntropyLoopWeightCallback InitialWeight { get; set; }

    public JVRMeasureOptions()
    {
      InitialWeight = EntropyLoopWeights.CONST;
      IncludeSelfEdge = false;
    }
  }
}