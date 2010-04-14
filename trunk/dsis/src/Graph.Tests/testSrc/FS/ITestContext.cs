using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Graph.Tests.FS
{
  public interface ITestContext
  {
    void CheckGraphNodesAndEdges(IEnumerable<Pair<int, IEnumerable<int>>> edges);

    void CheckDataHolder<TData>(IEnumerable<Pair<int, IEnumerable<int>>> edges, IEnumerable<Pair<int, TData>> values);
  }
}