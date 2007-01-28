using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.src.Adapter
{
  public class GraphCellImageBuilder<TCell> : ICellConnectionBuilder<TCell> 
    where TCell : ICellCoordinate<TCell>
  {
    private IGraph<TCell> myGraph;

    public GraphCellImageBuilder(IGraph<TCell> graph)
    {
      myGraph = graph;
    }

    public void ConnectToOne(TCell cell, TCell v)
    {
      INode<TCell> cellNode = myGraph.AddNode(cell);
      INode<TCell> vNode = myGraph.AddNode(v);
      myGraph.AddEdgeToNode(cellNode, vNode);
    }

    public void ConnectToMany(TCell cell, IEnumerable<TCell> v)
    {
      INode<TCell> fromNode = myGraph.AddNode(cell);
      foreach (TCell tCell in v)
      {
        INode<TCell> node = myGraph.AddNode(tCell);
        myGraph.AddEdgeToNode(fromNode, node);
      }
    }
  }
}
