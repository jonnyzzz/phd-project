using DSIS.Graph.Entropy.Impl;
using DSIS.Graph.Entropy.Impl.Eigen;

namespace DSIS.Graph.Entropy
{
  public static class EntropyEvaluator
  {
    public static IEntropyEvaluator GetLoopEntropyEvaluator()
    {
      return new EntropyEvaluatorImpl();
    }    

    public static IEntropyEvaluator GetEigentEvaluator()
    {
      return new EigenEntropyEvaluatorImpl();
    }
  }
}