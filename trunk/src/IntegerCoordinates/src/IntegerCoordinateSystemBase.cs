using System;
using DSIS.Core.System;

namespace DSIS.IntegerCoordinates
{
  public abstract class IntegerCoordinateSystemBase<T> where T : IIntegerCoordinate<T>
  {
    private readonly ISystemSpace mySystemSpace;
    private readonly double[] myCellSize;
 
    protected readonly double[] myCellSizeHalf;
    protected readonly long[] mySubdivision;
    protected readonly int myDimension;

    //from ISystemSpace. Optimization
    private readonly double[] myAreaLeftPoint;   
 
    public IntegerCoordinateSystemBase(ISystemSpace systemSpace, long[] subdivision)
    {
      mySystemSpace = systemSpace;
      mySubdivision = subdivision;
      myDimension = subdivision.Length;

      if (mySystemSpace.Dimension != mySubdivision.Length)
        throw new ArgumentException("Incorrect dimention and length", "subdivision");

      myCellSize = new double[mySubdivision.Length];
      myCellSizeHalf = new double[mySubdivision.Length];

      for (int i = mySubdivision.Length - 1; i >= 0; i--)
      {
        myCellSize[i] = (mySystemSpace.AreaRightPoint[i] - mySystemSpace.AreaLeftPoint[i])/subdivision[i];
        myCellSizeHalf[i] = myCellSize[i]/2;
      }

      myAreaLeftPoint = mySystemSpace.AreaLeftPoint;
    }

    public IntegerCoordinateSystemBase(ISystemSpace systemSpace)
      : this(systemSpace, systemSpace.InitialSubdivision)
    {
    }

    public double[] CellSize
    {
      get { return myCellSize; }
    }

    public double[] CellSizeHalf
    {
      get { return myCellSizeHalf; }
    }

    public long[] Subdivision
    {
      get { return mySubdivision; }
    }

    public ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
    }

    protected static long Ceil(double v)
    {
      return (long)(v);
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    protected long GetInitialCellsCount()
    {
      long cnt = 1;
      foreach (long l in mySubdivision)
      {
        cnt *= l;
      }
      return cnt;
    }

    public long ToInternal(double point, int i)
    {
      return Ceil((point - myAreaLeftPoint[i]) / myCellSize[i]);
    }

    public double ToExternal(long pt, int i)
    {
      return myAreaLeftPoint[i] + myCellSize[i] * pt;
    }

    public bool Intersects(long l, int axis)
    {
      return l >= 0 && l < mySubdivision[axis];
    }

    protected long[] GetSubdividedFactor(long[] division)
    {
      long[] div = new long[myDimension];
      for (int i = 0; i < div.Length; i++)
      {
        div[i] = mySubdivision[i]*division[i];
      }
      return div;
    }
  }
}