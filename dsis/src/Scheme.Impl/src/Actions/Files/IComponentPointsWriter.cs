using System.Collections.Generic;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.IntegerCoordinates;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public interface IComponentPointsWriter
  {
    IEnumerable<IGnuplotPointsFile> WriteComponents<T, Q>(T system, IReadonlyGraphStrongComponents<Q> comps)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;
  }
}