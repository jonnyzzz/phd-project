using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public class ComputationResult<T> where T : ICellCoordinate
  {
    public readonly ICollection<INode<T>> Contour;
    public readonly double Value;

    public ComputationResult(double value, ICollection<INode<T>> contour)
    {
      Value = value;
      Contour = contour;
    }
  }
}