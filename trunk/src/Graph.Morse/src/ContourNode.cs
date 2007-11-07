using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public class ContourNode<T> where T : ICellCoordinate<T>
  {
    public readonly INode<T> Node;
    public readonly double NodeCost;

    public ContourNode<T> Next; //tree-like     
    public NodeType Type; //M2 default<=> !M0 && !M1
    public double Value;

    public ContourNode(INode<T> node, double node_cost)
    {
      Type = NodeType.M2;
      Node = node;
      NodeCost = node_cost;
    }
  }
}