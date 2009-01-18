using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Utils.Bean;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class JVRMeasureOptions
  {
    [IncludeGenerate(Title = "Precision")]
    public double EPS { get; set;}

    [IncludeGenerate(Title = "Include 1-node loops")]
    public bool IncludeSelfEdge { get; set; }

    [IncludeGenerate(Title = "Initial weights"), IncludeValuesProvider(typeof(EntropyLoopWeights))]
    public IEntropyLoopWeightCallback InitialWeight { get; set; }

    public JVRMeasureOptions()
    {
      InitialWeight = EntropyLoopWeights.CONST;
      IncludeSelfEdge = false;
      EPS = 1e-3;
    }
  }
}