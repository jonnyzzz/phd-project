using DSIS.Utils.Bean;

namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public static class EntropyLoopWeights
  {
    [IncludeValue(Title = "1/x^2")]
    public static readonly IEntropyLoopWeightCallback MINUS_TWO = new EntropyLoopMunisTwoEntropyWeight();
    [IncludeValue(Title = "1/x")]
    public static readonly IEntropyLoopWeightCallback MINUS_ONE = new EntropyLoopMunisOneEntropyWeight();
    [IncludeValue(Title = "1")]
    public static readonly IEntropyLoopWeightCallback CONST = new EntropyLoopConstantWeight(1);
    [IncludeValue(Title = "x")]
    public static readonly IEntropyLoopWeightCallback ONE = new EntropyLoopLinearEntropyWeight();
    [IncludeValue(Title = "x^2")]
    public static readonly IEntropyLoopWeightCallback TWO = new EntropyLoopSquareEntropyWeight();

    private class EntropyLoopMunisOneEntropyWeight : IEntropyLoopWeightCallback
    {
      public double Weight(int length)
      {
        return 1.0/length;
      }

      public string Name
      {
        get { return "MinusOne"; }
      }
    }

    private class EntropyLoopSquareEntropyWeight : IEntropyLoopWeightCallback
    {
      public double Weight(int length)
      {
        return length*length;
      }

      public string Name
      {
        get { return "Two"; }
      }
    }

    private class EntropyLoopMunisTwoEntropyWeight : IEntropyLoopWeightCallback
    {
      public double Weight(int length)
      {
        return 1.0/length/length;
      }

      public string Name
      {
        get { return "MinusTwo"; }
      }
    }

    private class EntropyLoopLinearEntropyWeight : IEntropyLoopWeightCallback
    {
      public double Weight(int length)
      {
        return length;
      }

      public string Name
      {
        get { return "One"; }
      }
    }

    private class EntropyLoopConstantWeight : IEntropyLoopWeightCallback
    {
      private readonly double myWeight;

      public EntropyLoopConstantWeight(double weight)
      {
        myWeight = weight;
      }

      public double Weight(int length)
      {
        return myWeight;
      }

      public string Name
      {
        get { return "Const"; }
      }
    }
  }
}