using System;
using DSIS.Utils;

namespace DSIS.LineIterator
{
  public static class LineFactory
  {
    public static ILine CreateInitialLine(double eps, double[] pt1, double[] pt2)
    {
      if (pt1.Length != pt2.Length)
        throw new ArgumentException("Dimensions of pt1 and pt2 should be the same");

      var line = new Line<LinePointImpl>(eps.Fill(pt1.Length), new LinePointImpl(pt1));
      line.AddPointToEnd(new LinePointImpl(pt2));

      return line;
    }
  }
}