using DSIS.Utils.Bean;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  public enum StrangeEvaluatorType
  {
    [IncludeValue(Title = "Width Search 1")]
    WeightSearch_1,
    [IncludeValue(Title = "Width Search 2")]
    WeightSearch_2,
    [IncludeValue(Title = "Width Filtering")]
    WeightSearch_Filtering,
    [IncludeValue(Title = "Width Limited")]
    WeightSearch_Limited,

    [IncludeValue(Title = "Combinatorics")]
    Combinatorics
  }
}