namespace DSIS.SimpleRunner
{
  public interface IComputeEntropyListener
  {
    void OnComputeEntropyStarted();
    void OnComputeEntropyFinished(double value);    
  }
}