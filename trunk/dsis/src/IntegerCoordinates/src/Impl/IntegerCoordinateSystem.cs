using System;
using DSIS.Core.System;

namespace DSIS.IntegerCoordinates.Impl
{
  public class IntegerCoordinateSystem : 
    IntegerCoordinateSystemBase<IntegerCoordinateSystem, IntegerCoordinate>, 
    IProcessorFactory<IntegerCoordinate>, 
    IEXIntegerCoordinateSystemBase<IntegerCoordinateSystem, IntegerCoordinate>
  {
    private readonly IntegerCoordinate NULL = new IntegerCoordinate(-1);

    public IntegerCoordinateSystem(ISystemSpace systemSpace, long[] subdivision) : base(systemSpace, subdivision)
    {
    }

    public IntegerCoordinateSystem(ISystemSpace systemSpace) : base(systemSpace)
    {
    }

    public void TopLeftPoint(IntegerCoordinate point, double[] output)
    {
      for (int i = 0; i < myDimension; i++)
      {
        output[i] = ToExternal(point.GetCoordinate(i), i);
      }
    }

    public bool IsNull(IntegerCoordinate coord)
    {
      return coord.myCoordinate[0] < 0;
    }

    public IntegerCoordinate FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))        
        return NULL;

      var coordinate = new long[myDimension];
      for (int i = 0; i< myDimension; i++)
      {
        coordinate[i] = ToInternal(point[i], i);
      }
      return Create(coordinate);
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    public bool IsGenerated
    {
      get { return false; }
    }

    public bool Intersects(long l, int axis)
    {
      return l >= 0 && l < mySubdivision[axis];
    }

    public IntegerCoordinate Create(params long[] param)
    {
      return new IntegerCoordinate((long[]) param.Clone());
    }

    public IProcessorFactory<IntegerCoordinate> ProcessorFactory
    {
      get { return this; }
    }

    public void CenterPoint(IntegerCoordinate point, double[] output)
    {
      for (int i = 0; i < myDimension; i++)
      {
        output[i] = ToExternal(point.GetCoordinate(i), i) + myCellSizeHalf[i];
      }
    }

    public IntegerCoordinateSystem SubdividedCoordinateSystem(long[] division)
    {
      return new IntegerCoordinateSystem(SystemSpace, GetSubdividedFactor(division));
    }

    public IntegerCoordinateSystem ProjectedCoordinateSystem(long[] division)
    {
      var factor = GetProjectedFactor(division);
      return factor != null ? new IntegerCoordinateSystem(SystemSpace, factor) : null;
    }

/*    public void SaveCoordinate(IntegerCoordinate coord, IBinaryWriter writer)
    {
      for(int i = 0; i<myDimension; i++)
      {
        writer.WriteLong(coord.GetCoordinate(i));
      }
    }

    public IntegerCoordinate LoadCoordinate(IBinaryReader reader)
    {
      long[] t = new long[myDimension];
      for(int i=0; i<myDimension; i++)
      {
        t[i] = reader.ReadLong();
      }
      return new IntegerCoordinate(t);
    }*/

    public void DoGeneric(IIntegerCoordinateSystemWith with)
    {
      with.Do<IntegerCoordinateSystem, IntegerCoordinate>(this);
    }
  }
}