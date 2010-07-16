namespace DSIS.Graph.Morse.JVR
{
  public class ContourNode<T>
  {    
    private int myValue;

    public readonly T Node;
    public readonly double Cost;

    public ContourNode<T> Parent; //tree-like     
    
    public double Value;
    
    public ContourNode(T node, double node_cost)
    {
      myValue = 0;
      Node = node;
      Cost = node_cost;
    }

    public NodeType Type2
    {
      get { return (NodeType) myValue; }
      set { myValue = (int)value; }
    }

    public int Incoming
    {
      get { return myValue; }
      set { myValue = value; }
    }

    public override string ToString()
    {
      return string.Format("{0} {1:F}", Node, Cost);
    }
  }
}