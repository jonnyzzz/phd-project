using DSIS.Graph.Entropy.Impl;

namespace DSIS.Graph.Entropy
{
  public static class EntropyEvaluator
  {
    public static IEntropyEvaluator GetEntropyEvaluator()
    {
      return new EntropyEvaluatorImpl();
    }    
  }
}