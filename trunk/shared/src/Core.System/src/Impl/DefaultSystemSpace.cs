/*
 * Created by: Eugene Petrenko
 * Created: 5 ÿםגאנÿ 2007 ד.
 */

namespace DSIS.Core.System.Impl
{
  public class DefaultSystemSpace : ISystemSpace
  {
    private int myDimension;
    private double[] myAreaLeftPoint;
    private double[] myAreaRightPoint;
    private long[] myInitialSubdivision;

    public DefaultSystemSpace(int dimension, double[] areaLeftPoint, double[] areaRightPoint, long[] initialSubdivision)
    {
      myDimension = dimension;
      myAreaLeftPoint = areaLeftPoint;
      myAreaRightPoint = areaRightPoint;
      myInitialSubdivision = initialSubdivision;
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