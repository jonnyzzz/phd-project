using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.JVR;

namespace DSIS.Graph.Entropy.Impl.Loop.Weight
{
  public interface IEntropyWeightCallback
  {
    string Name { get; }
  }

  public interface IEntropyLoopWeightCallback : IEntropyWeightCallback
  {
    double Weight(int length);
  }
   
  public interface IEntropyEdgeWeightCallback : IEntropyWeightCallback
  {    
    double EdgeWeight<T, Q>(Q system, JVRPair<T> edge, int index)
      where Q : ICellCoordinateSystem<T>
      where T : ICellCoordinate;
  }
}