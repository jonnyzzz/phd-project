using System.Collections.Generic;

namespace DSIS.Graph.Morse
{
  public class ComputationResult<N>
    where N : class
  {
    public readonly bool IsMaximum;
    public readonly ICollection<N> Contour;
    public readonly double Value;

    public ComputationResult(double value, ICollection<N> contour, bool isMaximum)
    {
      Value = value;
      IsMaximum = isMaximum;
      Contour = contour;
    }
  }
}