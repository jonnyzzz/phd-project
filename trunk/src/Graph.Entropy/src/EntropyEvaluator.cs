using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl;

namespace DSIS.Graph.Entropy
{
  public static class EntropyEvaluator<T>
    where T : ICellCoordinate<T>
  {
    public static IEntropyEvaluator<T> GetLoopEntropyEvaluator()
    {
      return new StrangeEntropyEvaluatorImpl<T>(EntropyLoopConstantWeight.ONE);
    }    
    public static IEntropyEvaluator<T> GetLoopEntropyLinearEvaluator()
    {
      return new StrangeEntropyEvaluatorImpl<T>(EntropyLoopLinearEntropyWeight.VALUE);
    }    
    public static IEntropyEvaluator<T> GetLoopEntropySquareEvaluator()
    {
      return new StrangeEntropyEvaluatorImpl<T>(EntropyLoopSquareEntropyWeight.VALUE);
    }    

    public static IEntropyEvaluator<T> GetEigentEvaluator()
    {
      return null;// new EigenEntropyEvaluatorImpl();
    }
  }
}