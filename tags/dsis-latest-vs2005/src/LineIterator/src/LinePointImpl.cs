using System;
using System.Globalization;
using System.IO;
using DSIS.Core.System;

namespace DSIS.LineIterator
{
  public class LinePointImpl : ILinePoint<LinePointImpl>
  {
    private readonly double[] myPoint;

    public LinePointImpl(double[] point)
    {
      myPoint = point;
    }

    public LinePointImpl Middle(LinePointImpl point)
    {
      double[] pt = Create();
      for(int i = 0; i<myPoint.Length; i++)
      {
        pt[i] = (myPoint[i] + point.myPoint[i])/2.0;
      }
      return new LinePointImpl(pt);
    }

    public LinePointImpl Compute(IFunction<double> function)
    {
      double[] pt = Create();
      function.Input = myPoint;
      function.Output = pt;
      function.Evaluate();
      return new LinePointImpl(pt);
    }

    private double[] Create()
    {
      return new double[myPoint.Length];
    }

    public double Distance(LinePointImpl point)
    {
      double dist = 0;
      for (int i = 0; i < myPoint.Length; i++)
      {
        double c = myPoint[i] - point.myPoint[i];
        dist = Math.Max(dist, Math.Abs(c));
      }
      return dist;
    }

    public double EuclidDistance(LinePointImpl point)
    {
      double dist = 0;
      for (int i = 0; i < myPoint.Length; i++)
      {
        double c = myPoint[i] - point.myPoint[i];
        dist += c*c;
      }
      return Math.Sqrt(dist);
    }

    public void Save(TextWriter tw)
    {
      foreach (double d in myPoint)
      {                
        tw.Write(d.ToString("R", CultureInfo.InvariantCulture));
        tw.Write(' ');
      }
    }

    public int Dimension
    {
      get { return myPoint.Length; }
    }

    public bool IsContained(ISystemSpace space)
    {
      return space.Contains(myPoint);
    }

    public override string ToString()
    {
      StringWriter st = new StringWriter();
      st.Write("[");
      Save(st);
      st.Write("]");
      return st.ToString();
    }
  }
}