using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl;

namespace DSIS.Graph.Entropy
{
  public static class EntropyEvaluator<T>
    where T : ICellCoordinate<T>
  {
    public static IEntropyEvaluator<T> GetLoopEntropyEvaluator()
    {
      return new StrangeEntropyEvaluatorImpl<T>();
    }    

    public static IEntropyEvaluator<T> GetEigentEvaluator()
    {
      return null;// new EigenEntropyEvaluatorImpl();
    }
  }
}