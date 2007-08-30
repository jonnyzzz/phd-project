namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public class EntropyLoopConstantWeight : IEntropyLoopWeightCallback
  {
    public static readonly IEntropyLoopWeightCallback ONE = new EntropyLoopConstantWeight(1);

    private readonly double myWeight;

    public EntropyLoopConstantWeight(double weight)
    {
      myWeight = weight;
    }

    public double Weight(int length)
    {
      return myWeight;
    }
  }
}