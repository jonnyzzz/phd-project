using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  [EqualityComparer(typeof(DivideEqualityComparer))]
  public enum Divide : int
  {
    First,
    Middle,
    Second
  }
}