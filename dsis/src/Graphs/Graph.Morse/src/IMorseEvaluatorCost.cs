namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluatorCost<in T>
  {
    double Cost(T t);
  }
}