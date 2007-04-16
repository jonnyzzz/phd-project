using System;
using DSIS.Core.System;
using DSIS.IntegerCoordinates.Impl;

namespace DSIS.IntegerCoordinates.Generated
{
  public class IntegerCoordinateSystem2d : 
    IntegerCoordinateSystemBase<IntegerCoordinateSystem2d, IntegerCoordinate2d>, 
    IProcessorFactory<IntegerCoordinate2d>, 
    IEXIntegerCoordinateSystemBase<IntegerCoordinateSystem2d, IntegerCoordinate2d>
  {
    private readonly double myCellSizeHalfL1;
    private readonly double myCellSizeHalfL2;

    private readonly double myCellSizeL1;
    private readonly double myCellSizeL2;

    private readonly double myAreaLeftPointL1;
    private readonly double myAreaLeftPointL2;

    public IntegerCoordinateSystem2d(ISystemSpace systemSpace, long[] subdivision) : base(systemSpace, subdivision)
    {
      myCellSizeL1 = myCellSize[0];
      myCellSizeL2 = myCellSize[1];

      myCellSizeHalfL1 = myCellSizeHalf[0];
      myCellSizeHalfL2 = myCellSizeHalf[1];

      myAreaLeftPointL1 = myAreaLeftPoint[0];
      myAreaLeftPointL2 = myAreaLeftPoint[1];
    }

    public IntegerCoordinateSystem2d(ISystemSpace systemSpace) : this(systemSpace, systemSpace.InitialSubdivision)
    {
    }

    public new long ToInternal(double point, int i)
    {
      switch(i)
      {
        case 0:
          return ToInternalL1(point);
        case 1:
          return ToInternalL2(point);
        default:
          throw new OutOfMemoryException();
      }      
    }

    private long ToInternalL1(double point)
    {
      return Ceil((point - myAreaLeftPointL1)/ myCellSizeL1);
    }

    private long ToInternalL2(double point)
    {
      return Ceil((point - myAreaLeftPointL2) / myCellSizeL2);
    }

    public new double ToExternal(long pt, int i)
    {
      switch(i)
      {
        case 0:
          return ToExternalL1(pt);
        case 1:
          return ToExternalL2(pt);
        default:
          throw new OutOfMemoryException();
      }
    }

    private double ToExternalL1(long pt)
    {
      return myAreaLeftPointL1 + myCellSizeL1 * pt;
    }

    private double ToExternalL2(long pt)
    {
      return myAreaLeftPointL2 + myCellSizeL2 * pt;
    }

    public void TopLeftPoint(IntegerCoordinate2d point, double[] output)
    {
      output[0] = ToExternalL1(point.l1);
      output[1] = ToExternalL2(point.l2);
    }

    public void CenterPoint(IntegerCoordinate2d point, double[] output)
    {
      output[0] = ToExternalL1(point.l1) + myCellSizeHalfL1;
      output[1] = ToExternalL2(point.l2) + myCellSizeHalfL2;
    }

    public IntegerCoordinate2d Create(params long[] param)
    {
      return new IntegerCoordinate2d(param[0], param[1]);
    }

    public IntegerCoordinate2d Create(long l1, long l2)
    {
      return new IntegerCoordinate2d(l1, l2);        
    }

    public IProcessorFactory<IntegerCoordinate2d> ProcessorFactory
    {
      get { return this; }
    }

    public IntegerCoordinate2d FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))
        return null;

      long l1 = ToInternalL1(point[0]);
      long l2 = ToInternalL2(point[1]);

      return Create(l1, l2);
    }

    public IntegerCoordinateSystem2d SubdividedCoordinateSystem(long[] division)
    {
      return new IntegerCoordinateSystem2d(SystemSpace, division);
    }
  }
}