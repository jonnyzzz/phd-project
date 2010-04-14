using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  internal interface IHashholderController<T> where T : ICellCoordinate
  {
    void SetItem(JVRPair<T> pair, double value);
    /// <summary>
    /// Returns old value in hash holder
    /// </summary>
    double SetItem(T node, double output, double input);    
  }
}