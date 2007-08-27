namespace DSIS.Graph.Entropy.Impl
{
  public interface IEntropyLoopWeightCallback
  {
    double Weight(int length);
  }
}