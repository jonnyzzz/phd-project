using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Abstract
{
  public static partial class GraphAlgorithms
  {
    /// <summary>
    /// Converts all nodes of the Graph to a list of nodes.
    /// This method will allocate memory to store created list.
    /// </summary>
    /// <typeparam name="TCell"></typeparam>
    /// <param name="graph"></param>
    /// <param name="infos"></param>
    /// <returns></returns>
    public static ICountEnumerable<TCell> AsNodesCollection<TCell>(this IGraphStrongComponents<TCell> graph, IEnumerable<IStrongComponentInfo> infos)
      where TCell :ICellCoordinate
    {
      var list = new List<TCell>();
      list.AddRange(graph.GetCoordinates(infos));
      return new CountEnumerable<TCell>(list, list.Count);
    }
  }
}