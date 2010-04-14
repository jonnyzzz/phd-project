using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class GraphDataHolder<TData, TNode, TCell, TInh> : IGraphDataHolder<TData, TNode>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate 
    where TInh : AbstractGraph<TInh, TCell, TNode>, IGraphExtension<TNode, TCell>
  {
    private readonly AbstractGraph<TInh, TCell, TNode> myGraph;
    private readonly Func<TNode, TData> myDefaultFactory;

    private readonly string myCreationStacktrace;

    public GraphDataHolder(AbstractGraph<TInh, TCell, TNode> graph, Func<TNode, TData> defaultFactory)
    {
      myGraph = graph;
      myDefaultFactory = defaultFactory;
      CleanAll();

      myCreationStacktrace = Environment.StackTrace;
    }

    public TData GetData(TNode node)
    {
      var data = node.UserData;
      if (data is TData)
      {
        return (TData)data;
      }
      var d = myDefaultFactory(node);
      node.UserData = d;
      return d;      
    }    

    public void SetData(TNode node, TData data)
    {
      node.UserData = data;
    }

    public bool HasData(TNode node)
    {
      return node.UserData is TData;
    }

    public IEnumerable<TData> Values
    {
      get { return myGraph.NodesInternal.Where(HasData).Select(GetData); }
    }

    private void CleanAll()
    {
      foreach (var node in myGraph.NodesInternal)
      {
        node.UserData = null;
      }      
    }

    public void Dispose()
    {
      CleanAll();
      myGraph.DisposeDataHolder(this);
    }

    public override string ToString()
    {
      return "GraphDataHolder: " + myCreationStacktrace;
    }
  }
}