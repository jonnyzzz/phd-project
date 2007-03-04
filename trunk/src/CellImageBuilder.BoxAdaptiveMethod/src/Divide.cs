using DSIS.Core.Coordinates;

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