namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public class EntropyLoopMunisOneEntropyWeight : IEntropyLoopWeightCallback
  {
    public static readonly IEntropyLoopWeightCallback VALUE = new EntropyLoopMunisOneEntropyWeight();

    public double Weight(int length)
    {
      return 1.0/length;
    }    
  }
}