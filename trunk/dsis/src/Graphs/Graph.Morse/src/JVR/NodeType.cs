using System;

namespace DSIS.Graph.Morse.JVR
{
  public class NodeType
  {
    public static readonly NodeType M0 = new NodeType(1);// = -2,
    public static readonly NodeType M1 = new NodeType(2);// = -1,
    public static readonly NodeType M2 = new NodeType(3);// = 0

    public readonly int Value;

    private NodeType(int value)
    {
      Value = value;
    }

    public static NodeType FromValue(int v)
    {
      switch(v)
      {
        case 1:
          return M0;
        case 2:
          return M1;
        case 3:
          return M2;
        default:
          throw new ArgumentException("Value unexpected!", "v");
      }
    }
  }
}