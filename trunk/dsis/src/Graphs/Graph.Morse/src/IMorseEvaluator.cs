namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluator<T>
  {
    ComputationResult<T> Minimize();
  }
}