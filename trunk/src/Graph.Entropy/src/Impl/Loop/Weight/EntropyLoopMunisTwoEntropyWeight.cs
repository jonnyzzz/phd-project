namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public class EntropyLoopMunisTwoEntropyWeight : IEntropyLoopWeightCallback
  {
    public static readonly IEntropyLoopWeightCallback VALUE = new EntropyLoopMunisTwoEntropyWeight();

    public double Weight(int length)
    {
      return 1.0/length/length;
    }    
  }
}