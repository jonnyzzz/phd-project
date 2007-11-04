namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public interface IEntropyLoopWeightCallback
  {
    double Weight(int length);
    string Name { get;}
  }
}