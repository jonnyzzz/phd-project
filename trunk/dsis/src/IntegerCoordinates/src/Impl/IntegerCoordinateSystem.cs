using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Persistance.Streams;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Impl
{
  public class IntegerCoordinateSystem : 
    IntegerCoordinateSystemBase<IntegerCoordinateSystem, IntegerCoordinate>, 
    IProcessorFactory<IntegerCoordinate>, 
    IEXIntegerCoordinateSystemBase<IntegerCoordinateSystem, IntegerCoordinate>,
    ICellCoordinateSystemPersist<IntegerCoordinate>
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

    public bool IsNull(IntegerCoordinate coord)
    {
      return coord == null;      
    }

    public IEqualityComparer<IntegerCoordinate> Comparer
    {
      get { return new IntegerCoordinateEqualityComparer(); }
    }

    public IntegerCoordinate FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))        
        return null;

      var coordinate = new long[myDimension];
      for (int i = 0; i< myDimension; i++)
      {
        coordinate[i] = ToInternal(point[i], i);
      }
      return Create(coordinate);
    }

    public long ToInternal(double point, int i)
    {
      if (point < myAreaLeftPoint[i]) return -1;
      if (point > myAreaRightPoint[i]) return mySubdivision[i];

      return Ceil((point - myAreaLeftPoint[i]) / myCellSize[i]);
    }

    public double ToExternal(long pt, int i)
    {
      return myAreaLeftPoint[i] + myCellSize[i] * pt;
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

    public void Save(IOutputStream stream, IntegerCoordinate cell)
    {
      //TODO: Save all bytes at once
      for(var i = 0; i < Dimension; i++)
      {
        stream.Write(LongConverter.ToBytes(cell.myCoordinate[i]), 0, LongConverter.Size);
      }
    }

    public IntegerCoordinate Load(IInputStream stream)
    {
      //TODO: Read all bytes at once
      var arr = new long[Dimension];
      var buff = new byte[LongConverter.Size];
      for(var i = 0; i < Dimension; i++)
      {
        stream.Read(buff, 0, buff.Length);
        arr[i] = LongConverter.FromBytes(buff);
      }
      return Create(arr);
    }
  }
}