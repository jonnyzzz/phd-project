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
        var graph = myComps.AsGraph(new[] {info});
        graph.DoGeneric(new Proxy(this));
      }
    }

    public IGraphMeasure<T> Entropy()
    {
      return new GraphMeasure<T, NodePair<T>>("Long Path", myValues.Dictionary,
                                         EqualityComparerFactory<T>.GetReferenceComparer(), myNorm,
                                         myComps.CoordinateSystem);
    }

    private class Proxy : IReadonlyGraphWith<T>
    {
      private readonly PathBuilder<T> myBuilder;

      public Proxy(PathBuilder<T> builder)
      {
        myBuilder = builder;
      }

      public void With<TNode>(IReadonlyGraph<T, TNode> graph) where TNode : class, INode<T>
      {
        new Processor<TNode>(graph, myBuilder).Process();
      }
    }

    private class Processor<TNode> where TNode : class, INode<T>
    {
      private readonly IReadonlyGraph<T, TNode> graph;
      private readonly PathBuilder<T> myHost;

      public Processor(IReadonlyGraph<T, TNode> graph, PathBuilder<T> host)
      {
        this.graph = graph;
        myHost = host;
      }

      public void Process()
      {
        using (var holder = graph.CreateDataHolder(x => new InfiniteEnumerator<TNode>(graph.GetEdgesInternal(x).GetEnumerator())))
        {
          BuildPath(holder, graph.NodesInternal.First());
        }

      }

      private void BuildPath(IGraphDataHoler<InfiniteEnumerator<TNode>, TNode> holder, TNode startNode)
      {
        var start = startNode;
        int initialValues = myHost.myValues.Count;

        while (!ReferenceEquals(start, startNode) || myHost.myValues.Count - initialValues != graph.EdgesCount)
        {
          var next = GetNextNode(holder, start);

          myHost.myValues.Add(new NodePair<T>(start.Coordinate, next.Coordinate), 1);
          myHost.myNorm++;

          start = next;
        }
      }

      private static TNode GetNextNode(IGraphDataHoler<InfiniteEnumerator<TNode>, TNode> holder, TNode from)
      {
        var outs = holder.GetData(from);
        outs.MoveNext();
        return outs.Current;
      }
    }
  }
}