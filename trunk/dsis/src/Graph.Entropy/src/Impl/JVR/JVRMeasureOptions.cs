using System;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Utils.Bean;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public enum JVRExitCondition
  {
    [IncludeValue(Title = "When current node error < eps")]
    MaxNodeError,
    [IncludeValue(Title = "When current node error < eps * cell volume")]
    MaxRelativeNodeError,
    [IncludeValue(Title = "When total error < eps")]
    SummError,
    [IncludeValue(Title = "When step weight change < eps")]
    ChangeError
  }

  [Serializable]
  public class JVRMeasureOptions
  {
    [IncludeGenerate(Title = "Exit condition")]
    public JVRExitCondition ExitCondition { get; set; }

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
      ExitCondition = JVRExitCondition.MaxNodeError;
      EPS = 1e-3;
    }
  }
}