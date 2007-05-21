using System.Text;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class PointGraphNode
  {
    public readonly double[] PointX;
    public double[] PointY = null;

    public Hashset<PointGraphNode> Edges = new Hashset<PointGraphNode>();

    public PointGraphNode(double[] pointX)
    {
      PointX = pointX;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("[");
      foreach (double d in PointX)
      {
        sb.AppendFormat("{0}, ", d);
      }
      sb.Append("]");
      return sb.ToString();
    }
  }
}