/*
 * Created by: Eugene Petrenko
 * Created: 5 ������ 2007 �.
 */

using System;

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
  }
}