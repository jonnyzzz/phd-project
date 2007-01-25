using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.src.Adapter
{
  public class GraphCellImageBuilder<TCell, TValue> : ICellConnectionBuilder<TCell> 
    where TCell : ICellCoordinate<TCell>
  {
    private IGraph<TCell, TValue> myGraph;

    public GraphCellImageBuilder(IGraph<TCell, TValue> graph)
    {
      myGraph = graph;
    }

    public void ConnectToOne(TCell cell, TCell v)
    {
      INode<TCell, TValue> cellNode = myGraph.AddNode(cell);
      INode<TCell, TValue> vNode = myGraph.AddNode(v);
      myGraph.AddEdgeToNode(cellNode, vNode);
    }

    public void ConnectToMany(TCell cell, IEnumerable<TCell> v)
    {
      INode<TCell, TValue> fromNode = myGraph.AddNode(cell);
      foreach (TCell tCell in v)
      {
        INode<TCell, TValue> node = myGraph.AddNode(tCell);
        myGraph.AddEdgeToNode(fromNode, node);
      }
    }
  }
}
