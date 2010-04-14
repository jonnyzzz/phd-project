using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class AbstractGraphComponentIdHolder<TInh, TNode, TCell> : IGraphDataHolder<uint, TNode> 
    where TNode : Node<TNode, TCell> 
    where TCell : ICellCoordinate
    where TInh : AbstractGraph<TInh, TCell, TNode>, IGraphExtension<TNode, TCell>
  {
    private readonly AbstractGraph<TInh, TCell, TNode> myGraph;

    public AbstractGraphComponentIdHolder(AbstractGraph<TInh, TCell, TNode> graph)
    {
      myGraph = graph;
    }

    public void Dispose()
    {
      //NOP
    }

    public uint GetData(TNode node)
    {
      return node.ComponentId;
    }

    public void SetData(TNode node, uint data)
    {
      node.SetComponentId(data);
    }

    public bool HasData(TNode node)
    {
      return true;
    }

    public IEnumerable<uint> Values
    {
      get { return myGraph.NodesInternal.Select(GetData); }
    }

    public void CleanAll()
    {
      //NOP
    }
  }
}