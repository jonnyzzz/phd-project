namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluator<T>
  {
    ComputationResult<T> Minimize();
  }

  public interface IMorseEvaluatorSaveSupport<T>
  {
    void AddPersist(IMorseEvaluatorPersist<T> persist);
  }
}