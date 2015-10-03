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


    [IncludeValue(Title = "When average error < eps")]
    AvgSummError,

   
    [IncludeValue(Title = "When total error < eps")]
    SummError,   
    
    [IncludeValue(Title = "When total error < eps * number of cells")]
    RelativeSummError,
    

    [IncludeValue(Title = "When step nodes weight change < eps")]
    NodeChangeError,
    
    [IncludeValue(Title = "When step nodes weight change < eps * cell volume")]
    NodeRelativeChangeError,
    
    [IncludeValue(Title = "When step edges weight change < eps")]
    EdgesChangeError,
    
    [IncludeValue(Title = "When step edges weight change < eps * cell volume")]
    EdgesRelativeChangeError,
  }

  [Serializable]
  public class JVRMeasureOptions
  {
    [IncludeGenerate(Title = "Exit condition")]
    public JVRExitCondition ExitCondition { get; set; }

    [IncludeGenerate(Title = "eps")]
    public double EPS { get; set;}

    [IncludeGenerate(Title = "Include 1-node loops")]
    public bool IncludeSelfEdge { get; set; }

    [IncludeGenerate(Title = "Initial weights"), IncludeValuesProvider(typeof(EntropyEdgeWeights))]
    public IEntropyEdgeWeightCallback InitialWeight { get; set; }

    public JVRMeasureOptions()
    {
      InitialWeight = EntropyEdgeWeights.CONST;
      IncludeSelfEdge = false;
      ExitCondition = JVRExitCondition.MaxNodeError;
      EPS = 1e-3;
    }

    public string Present
    {
      get {
        return string.Format("JVR[Exit={0},Eps={1},self={2},Init={3}", ExitCondition, EPS, IncludeSelfEdge,
                             InitialWeight.Name); }
    }
  }
}