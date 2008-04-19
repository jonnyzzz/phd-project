using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public sealed class DivideEqualityComparer : IEqualityComparer<Divide>
  {
    public bool Equals(Divide x, Divide y)
    {
      return x == y;
    }

    public int GetHashCode(Divide obj)
    {
      return (int) obj;
    }
  }
}