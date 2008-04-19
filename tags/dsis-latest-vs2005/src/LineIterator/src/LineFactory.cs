using System;

namespace DSIS.LineIterator
{
  public static class LineFactory
  {
    public static ILine CreateInitialLine(double eps, double[] pt1, double[] pt2)
    {
      if (pt1.Length != pt2.Length)
        throw new ArgumentException("Dimensions of pt1 and pt2 should be the same");

      Line<LinePointImpl> line = new Line<LinePointImpl>(eps, new LinePointImpl(pt1));
      line.AddPointToEnd(new LinePointImpl(pt2));

      return line;
    }
  }
}