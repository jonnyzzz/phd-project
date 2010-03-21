using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public class SmartPathBuilder<T>
    where T : ICellCoordinate
  {
    private readonly IGraphStrongComponents<T> myComps;
    protected readonly Vector<NodePair<T>> myValues = new Vector<NodePair<T>>();
    private int myNorm = 0;

    public SmartPathBuilder(IGraphStrongComponents<T> comps)
    {
      myComps = comps;
    }

    public IGraphMeasure<T> Entropy()
    {
      return
        new GraphMeasure<T, NodePair<T>>("Smart Long Path", myValues.Dictionary,
                                         EqualityComparerFactory<T>.GetReferenceComparer(), myNorm,
                                         myComps.CoordinateSystem);
    }

    public void BuildPath()
    {
      foreach (IStrongComponentInfo info in myComps.Components)
      {
        var graph = myComps.AsGraph(new[] { info });

        graph.DoGeneric(new Proxy(this));

        GCHelper.Collect();
      }
    }

    private class Proxy : IReadonlyGraphWith<T>
    {
      private readonly SmartPathBuilder<T> myHost;

      public Proxy(SmartPathBuilder<T> host)
      {
        myHost = host;
      }

      public void With<TNode>(IReadonlyGraph<T, TNode> graph) where TNode : class, INode<T>
      {
        var proc = new GraphProcessor<TNode>(graph, myHost.myValues, myHost.myNorm);
        proc.ProcessGraph();
        myHost.myNorm = proc.Norm;
      }
    }

    private class GraphProcessor<TNode> where TNode : class, INode<T>
    {
      private readonly IReadonlyGraph<T, TNode> graph;
      private static readonly INodeState<T, TNode> ourInitialState = new ThisNodeState<T, TNode>();

      protected readonly Vector<NodePair<T>> myValues;
      private int myNorm;

      public GraphProcessor(IReadonlyGraph<T, TNode> graph, Vector<NodePair<T>> values, int norm)
      {
        this.graph = graph;
        myValues = values;
        myNorm = norm;
      }

      public int Norm
      {
        get { return myNorm; }
      }

      public void ProcessGraph()
      {
        using (var holder = graph.CreateDataHolder(x => ourInitialState))
        {
          int initialComponents = myValues.Count;

          while (myValues.Count - initialComponents < graph.EdgesCount)
          {
            foreach (var node in graph.NodesInternal)
            {
              //          if (GetNodeState(node) is ThisNodeState<T>)
              {
                BuildPath(node, holder);
              }
            }
          }
        }
      }

      private void BuildPath(TNode startNode, IGraphDataHoler<INodeState<T,TNode>, TNode> holder)
      {
        var start = startNode;
        do
        {
          var next = GetNextNode(startNode, start, holder);

          myValues.Add(new NodePair<T>(start.Coordinate, next.Coordinate), 1);
          myNorm++;

          start = next;
        } while (!ReferenceEquals(start, startNode));
      }


      private TNode GetNextNode(TNode startNode, TNode from, IGraphDataHoler<INodeState<T,TNode>, TNode> holder)
      {
        TNode result;
        holder.SetData(from, holder.GetData(from).GetNextNode(graph, startNode, from, out result, holder));

        return result;
      }
    }

    internal static bool IsNodeOpened<TNode>(TNode from, IGraphDataHoler<INodeState<T, TNode>, TNode> holder)
      where TNode : class, INode<T>
    {
      return holder.GetData(from) is ThisNodeState<T,TNode>;
    }
  }
}
