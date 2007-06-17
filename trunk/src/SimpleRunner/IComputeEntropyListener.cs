using DSIS.Graph;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public interface IComputeEntropyListener
  {
    void OnComputeEntropyStarted();
    void OnComputeEntropyFinished(double value);    
  }
}