namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public class EntropyLoopLinearEntropyWeight : IEntropyLoopWeightCallback
  {
    public static readonly IEntropyLoopWeightCallback VALUE = new EntropyLoopLinearEntropyWeight();

    public double Weight(int length)
    {
      return length;
    }    
  }
}