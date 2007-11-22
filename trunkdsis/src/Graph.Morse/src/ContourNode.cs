using System;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public class ContourNode<T> where T : ICellCoordinate<T>
  {
    private int myValue = 0;

    public readonly INode<T> Node;
    public readonly double NodeCost;

    public ContourNode<T> Next; //tree-like     
    
    public double Value;
    
    public ContourNode(INode<T> node, double node_cost)
    {
      myValue = 0;
      Node = node;
      NodeCost = node_cost;
    }

    public NodeType Type2
    {
      get { return NodeType.FromValue(myValue); }
      set { myValue = value.Value; }
    }

    public int Incoming
    {
      get { return myValue; }
      set { myValue = value; }
    }


    public override string ToString()
    {
      return string.Format("{0} {1:F}", Node, NodeCost);
    }

    public override bool Equals(object obj)
    {
      throw new NotImplementedException();
    }
  }
}