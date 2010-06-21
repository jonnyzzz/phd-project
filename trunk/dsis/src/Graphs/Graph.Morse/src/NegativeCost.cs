namespace DSIS.Graph.Morse
{
  public class NegativeCost<T> : IMorseEvaluatorCost<T>
  {
    private readonly IMorseEvaluatorCost<T> myHost;

    public NegativeCost(IMorseEvaluatorCost<T> host)
    {
      myHost = host;
    }

    public double Cost(T t)
    {
      return -myHost.Cost(t);
    }
  }
}