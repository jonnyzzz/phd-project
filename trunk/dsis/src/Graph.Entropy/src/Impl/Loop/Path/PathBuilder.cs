using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;
using System.Linq;

namespace DSIS.Graph.Entropy.Impl.Loop.Path
{
  public class PathBuilder<T> where T : ICellCoordinate
  {
    private readonly IGraphStrongComponents<T> myComps;

    protected readonly Vector<NodePair<T>> myValues = new Vector<NodePair<T>>();
    private int myNorm;

    public PathBuilder(IGraphStrongComponents<T> comps)
    {
      myComps = comps;
    }

    public void BuildPath()
    {
      foreach (IStrongComponentInfo info in myComps.Components)
      {
        var graph = (IReadonlyGraphEx<T>)myComps.AsGraph(new[] {info});
        using (var holder = graph.CreateDataHolder(x => new InfiniteEnumerator<INode<T>>(graph.GetEdges(x).GetEnumerator())))
        {
          BuildPath(graph, holder, graph.Nodes.First());
        }
      }
    }

    private void BuildPath(IReadonlyGraph graph, IGraphDataHoler<InfiniteEnumerator<INode<T>>, INode<T>> holder,
                           INode<T> startNode)
    {
      var start = startNode;
      int initialValues = myValues.Count;

      while (!ReferenceEquals(start, startNode) || myValues.Count - initialValues != graph.EdgesCount)
      {
        var next = GetNextNode(holder, start);

        myValues.Add(new NodePair<T>(start.Coordinate, next.Coordinate), 1);
        myNorm++;

        start = next;
      }
    }

    private static INode<T> GetNextNode(IGraphDataHoler<InfiniteEnumerator<INode<T>>, INode<T>> holder, INode<T> from)
    {
      var outs = holder.GetData(from);
      outs.MoveNext();
      return outs.Current;
    }

    public IGraphMeasure<T> Entropy()
    {
      return new GraphMeasure<T, NodePair<T>>("Long Path", myValues.Dictionary,
                                         EqualityComparerFactory<T>.GetReferenceComparer(), myNorm,
                                         myComps.CoordinateSystem);
    }
  }
}