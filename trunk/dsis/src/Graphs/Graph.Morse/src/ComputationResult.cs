using System.Collections.Generic;

namespace DSIS.Graph.Morse
{
  public class ComputationResult
  {
    public readonly double Value;
    public readonly double Count;

    public ComputationResult(double value, double count)
    {
      Value = value;
      Count = count;
    }
  }

  public class ComputationResult<T> : ComputationResult
  {
    public readonly ICollection<T> Contour;

    public ComputationResult(double value, ICollection<T> contour) : base(value, contour.Count)
    {
      Contour = contour;
    }

    public ComputationResult<T> Negative()
    {
      return new ComputationResult<T>(-Value, Contour);
    }
  }
}