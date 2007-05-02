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
  }
}