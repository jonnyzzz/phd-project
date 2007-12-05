using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  internal interface IHashholderController<T> where T : ICellCoordinate<T>
  {
    void SetItem(JVRPair<T> pair, double value);
    void SetItem(T node, double output, double input);    
  }
}