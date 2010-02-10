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
    private static readonly INodeState<T> ourInitialState = new ThisNodeState<T>();

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
        IGraph<T> graph = myComps.AsGraph(new[] {info});

        using (var holder = graph.CreateDataHolder(x => ourInitialState))
        {
          int initialComponents = myValues.Count;

          while (myValues.Count - initialComponents < graph.EdgesCount)
          {
            foreach (INode<T> node in graph.Nodes)
            {
              //          if (GetNodeState(node) is ThisNodeState<T>)
              {
                BuildPath(graph, node, holder);
              }
            }
          }
        }
      }

      GCHelper.Collect();
    }

    private void BuildPath(IGraph<T> graph, INode<T> startNode, IGraphDataHoler<INodeState<T>, INode<T>> holder)
    {      
      var start = startNode;
      do
      {
        var next = GetNextNode(graph, startNode, start, holder);

        myValues.Add(new NodePair<T>(start.Coordinate, next.Coordinate), 1);
        myNorm++;

        start = next;
      } while (!ReferenceEquals(start, startNode));
    }

    internal static INode<T> GetNextNode(IGraph<T> graph, INode<T> startNode, INode<T> from, IGraphDataHoler<INodeState<T>, INode<T>> holder)
    {
      INode<T> result;
      holder.SetData(from,GetNodeState(from, holder).GetNextNode(graph, startNode, from, out result, holder));
      
      return result;
    }

    internal static bool IsNodeOpened(INode<T> from, IGraphDataHoler<INodeState<T>, INode<T>> holder)
    {
      return GetNodeState(from, holder) is ThisNodeState<T>;        
    }

    private static INodeState<T> GetNodeState(INode<T> from, IGraphDataHoler<INodeState<T>, INode<T>> holder)
    {
      return holder.GetData(from);
    }
  }
}