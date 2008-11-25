using DSIS.Utils.Bean;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  public enum StrangeEvaluatorStrategy
  {
    [IncludeValue(Title = "First")]
    FIRST,
    [IncludeValue(Title = "Smart")]
    SMART,
    [IncludeValue(Title = "Combinatorics")]
    COMBINATORICS
  }
}