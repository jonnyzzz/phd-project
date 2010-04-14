namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class GraphEntropy : IGraphEntropy
  {
    private readonly double myValue;
    private readonly string myName;

    public GraphEntropy(string name, double value)
    {
      myName = name;
      myValue = value;
    }

    public string Method
    {
      get { return myName; }
    }

    public double GetEntropy()
    {
      return myValue;
    }
  }
}