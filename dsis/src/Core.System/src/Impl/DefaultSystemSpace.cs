/*
 * Created by: Eugene Petrenko
 * Created: 5 ÿםגאנÿ 2007 ד.
 */

using System;
using System.Text;

namespace DSIS.Core.System.Impl
{
  public class DefaultSystemSpace : ISystemSpace
  {
    private readonly int myDimension;
    private readonly double[] myAreaLeftPoint;
    private readonly double[] myAreaRightPoint;
    private readonly long[] myInitialSubdivision;

    public DefaultSystemSpace(int dimension, double[] areaLeftPoint, double[] areaRightPoint, long[] initialSubdivision)
    {
      myDimension = dimension;
      myAreaLeftPoint = areaLeftPoint;
      myAreaRightPoint = areaRightPoint;
      myInitialSubdivision = initialSubdivision;

      if (myAreaLeftPoint.Length != myDimension)
        throw new ArgumentException("wrong size", "areaLeftPoint");
      if (myAreaRightPoint.Length != myDimension)
        throw new ArgumentException("wrong size", "areaRightPoint");
      if (initialSubdivision.Length != myDimension)
        throw new ArgumentException("wrong size", "initialSubdivision");
    }

    #region ISystemSpace Members

    public double[] AreaLeftPoint
    {
      get { return myAreaLeftPoint; }
    }

    public double[] AreaRightPoint
    {
      get { return myAreaRightPoint; }
    }

    public bool Contains(double[] point)
    {
      for (int i = 0; i < Dimension; i++)
      {
        if (AreaLeftPoint[i] > point[i])
          return false;
        if (AreaRightPoint[i] < point[i])
          return false;
      }
      return true;
    }

    public bool ContainsRect(double[] left, double[] right)
    {
      for (int i = 0; i < Dimension; i++)
      {
        if (!
            (((left[i] <= myAreaLeftPoint[i]) && (myAreaLeftPoint[i] <= right[i])) ||
             ((left[i] <= myAreaRightPoint[i]) && (myAreaRightPoint[i] <= right[i])) ||
             ((myAreaLeftPoint[i] <= left[i]) && (right[i] <= myAreaRightPoint[i])))
          ) return false;
      }
      return true;
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    public long[] InitialSubdivision
    {
      get { return myInitialSubdivision; }
    }

    #endregion

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("Dim={0}, L=(", myDimension);
      for (int i = 0; i < myDimension; i++)
        sb.AppendFormat("{0}, ", myAreaLeftPoint[i]);
      sb.Append("), R=(");
      for (int i = 0; i < myDimension; i++)
        sb.AppendFormat("{0}, ", myAreaRightPoint[i]);
      sb.Append("), Grid=(");
      for (int i = 0; i < myDimension; i++)
        sb.AppendFormat("{0}, ", myInitialSubdivision[i]);
      sb.Append(")");
      return sb.ToString();
    }
  }
}