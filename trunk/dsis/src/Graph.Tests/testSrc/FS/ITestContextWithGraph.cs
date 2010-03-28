using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Tests.FS
{
  public interface ITestContextWithGraph<TCell> where TCell : ICellCoordinate
  {
    void CheckBuiltGraphEdges(IEnumerable<Pair<int, IEnumerable<int>>> edges);
    void DumpGraph();
  }
}