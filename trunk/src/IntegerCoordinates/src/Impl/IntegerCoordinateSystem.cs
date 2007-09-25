using DSIS.Core.System;
using DSIS.Persistance;

namespace DSIS.IntegerCoordinates.Impl
{
  public class IntegerCoordinateSystem : IntegerCoordinateSystemBase<IntegerCoordinateSystem, IntegerCoordinate>, IProcessorFactory<IntegerCoordinate>, IEXIntegerCoordinateSystemBase<IntegerCoordinateSystem, IntegerCoordinate>
  {
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

    public IntegerCoordinate FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))
        return null;

      long[] coordinate = new long[myDimension];
      for (int i = 0; i< myDimension; i++)
      {
        coordinate[i] = ToInternal(point[i], i);
      }
      return Create(coordinate);
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
      long[] factor = GetProjectedFactor(division);
      return factor != null ? new IntegerCoordinateSystem(SystemSpace, factor) : null;
    }

    public void SaveCoordinate(IntegerCoordinate coord, IBinaryWriter writer)
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
    }
  }
}