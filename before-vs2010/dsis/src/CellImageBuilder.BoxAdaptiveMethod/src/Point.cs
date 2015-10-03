using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  [EqualityComparer(typeof(PointEqualityComparer))]
  public class Point
  {
    private static readonly int[] POW_2 = new int[31];
    private static readonly double[] POW_1_2 = new double[31];
    private static readonly Dictionary<int, int[]> ARRAYS_ZERO = new Dictionary<int, int[]>();
    private static readonly Dictionary<int, int[]> ARRAYS_ONES = new Dictionary<int, int[]>();

    private readonly int myPower; //power of 2 as common devider
    private readonly int[] myPoints;

    static Point()
    {
      int l = 1;
      for (int i = 0; i < 31; i++)
      {
        POW_2[i] = l;
        POW_1_2[i] = 1.0/l;
        l *= 2;
      }
    }

    private Point(int power, int[] coordinate)
    {
      myPoints = coordinate;
      myPower = power;
    }

    public void Evaluate(double[] left, double[] right, double[] output)
    {
      double p = POW_1_2[myPower];
      for (int i = 0; i < myPoints.Length; i++)
      {
        double tmp = myPoints[i]*p;
        output[i] = right[i]*tmp + (1 - tmp)*left[i];
      }
    }

    public static Point Middle(Point p1, Point p2, Divide[] type)
    {
      int dim = type.Length;
      int[] point = new int[dim];
      int[] point2 = new int[dim];

      int m1;
      int m2;

      int v = p2.myPower - p1.myPower;
      if (v > 0)
      {
        m1 = POW_2[v];
        m2 = POW_2[0];        
      } else {
        m1 = POW_2[0];
        m2 = POW_2[-v];
      }                  
      int power = Math.Max(p1.myPower, p2.myPower) + 1;

      for (int i = 0; i < dim; i++)
      {
        switch (type[i])
        {
          case Divide.First:
            point[i] = (m1*p1.myPoints[i]) << 1;
            break;
          case Divide.Middle:
            point[i] = m1*p1.myPoints[i] + m2*p2.myPoints[i];
            break;
          case Divide.Second:
            point[i] = (m2*p2.myPoints[i]) << 1;
            break;
        }
      }
      bool b = true;
      while (power > 0 && b)
      {
        for (int i = 0; i < point.Length; i++)
        {
          if ((point[i] & 0x1) == 0)
            point2[i] = point[i] >> 1;
          else
          {
            point2[i] = point[i];
            b = false;
            break;
          }
        }
        if (b)
        {
          int[] t = point2;
          point2 = point;
          point = t;
          power--;
        }
      }
      return new Point(power, point);
    }

    public int[] Points
    {
      get { return myPoints; }
    }

    public int Power
    {
      get { return myPower; }
    }

    public static Point Create(int[] pt)
    {
      return new Point(0, pt);
    }

    internal static Point CreatePoint(int dim, int v)
    {
      int[] pt = new int[dim];
      for (int i = 0; i < dim; i++)
      {
        pt[i] = v;
      }
      return new Point(0, pt);
    }

    private static int[] FillArray(int dim, bool zeros)
    {
      int[] result;
      Dictionary<int, int[]> dic = zeros ? ARRAYS_ZERO : ARRAYS_ONES;

      if (!dic.TryGetValue(dim, out result))
      {
        result = new int[dim];
        int v = zeros ? 0 : 1;
        for (int i = 0; i < dim; i++)
          result[i] = v;

        dic[dim] = result;
      }
      return result;
    }

    public static Point CreateTopLeft(int dim)
    {
      return Create(FillArray(dim, true));
    }

    public static Point CreateBottomRight(int dim)
    {
      return Create(FillArray(dim, false));
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Point)) return false;
      Point point = (Point) obj;
      return EqualsInternal(point);
    }

    public bool EqualsInternal(Point point)
    {
      if (myPower != point.myPower)
        return false;

      for (int i = 0; i < point.myPoints.Length; i++)
      {
        if (myPoints[i] != point.myPoints[i])
          return false;
      }
      return true;
    }

    public override int GetHashCode()
    {
      return GetHashCodeInternal();
    }

    internal int GetHashCodeInternal()
    {
      int l = 0;
      for (int i = 0; i < myPoints.Length; i++)
      {
        l = l*13 + myPoints[i];
      }
      return l*17 + myPower;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder(string.Format("{0}, [", myPower));
      foreach (int point in myPoints)
      {
        sb.AppendFormat("{0}, ", point);
      }
      sb.Append("]");
      return sb.ToString();
    }
  }
}