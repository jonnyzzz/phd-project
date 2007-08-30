using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public class EntropyLoopSquareEntropyWeight : IEntropyLoopWeightCallback
  {
    public static readonly IEntropyLoopWeightCallback VALUE = new EntropyLoopLinearEntropyWeight();

    public double Weight(int length)
    {
      return length;
    }    
  }
}