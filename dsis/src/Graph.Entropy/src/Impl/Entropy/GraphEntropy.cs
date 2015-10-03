namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class GraphEntropy : IGraphEntropy
  {
    private readonly double myValue;

    public GraphEntropy(double value)
    {
      myValue = value;
    }

    public double GetEntropy()
    {
      return myValue;
    }
  }
}