using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Persistance;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Impl
{
  public interface IEXIntegerCoordinateSystemBase<TInh, Q>  : IIntegerCoordinateSystem<Q>
    where TInh : IIntegerCoordinateSystem<Q> 
    where Q : IIntegerCoordinate
  {
    TInh SubdividedCoordinateSystem(long[] division);
    TInh ProjectedCoordinateSystem(long[] division);
  }

  public abstract class IntegerCoordinateSystemBase<TInh, Q> 
    where TInh : class, IEXIntegerCoordinateSystemBase<TInh, Q> 
    where Q : IIntegerCoordinate
  {
    private readonly ISystemSpace mySystemSpace;

    protected readonly double[] myCellSize; 
    protected readonly double[] myCellSizeHalf;
    protected readonly long[] mySubdivision;
    protected readonly int myDimension;

    //from ISystemSpace. Optimization
    protected readonly double[] myAreaLeftPoint;
    protected readonly double[] myAreaRightPoint;

    private readonly TInh myInh;

    protected IntegerCoordinateSystemBase(ISystemSpace systemSpace, long[] subdivision)
    {
      myInh = (TInh)(object)this;

      mySystemSpace = systemSpace;
      mySubdivision = subdivision;
      myDimension = subdivision.Length;

      if (mySystemSpace.Dimension != mySubdivision.Length)
        throw new ArgumentException("Incorrect dimention and length", "subdivision");

      myCellSize = new double[mySubdivision.Length];
      myCellSizeHalf = new double[mySubdivision.Length];

      for (int i = 0; i < mySubdivision.Length;  i++)
      {
        myCellSize[i] = (mySystemSpace.AreaRightPoint[i] - mySystemSpace.AreaLeftPoint[i]) / subdivision[i];
        myCellSizeHalf[i] = myCellSize[i] / 2;
      }

      myAreaLeftPoint = mySystemSpace.AreaLeftPoint;
      myAreaRightPoint = mySystemSpace.AreaRightPoint;
    }

    protected IntegerCoordinateSystemBase(ISystemSpace systemSpace)
      : this(systemSpace, systemSpace.InitialSubdivision)
    {
    }

    public ICellCoordinateCollection<Q> InitialSubdivision
    {
      get { return new CellCoordinateCollection<Q>(myInh, GetInitialSubdivision(), GetInitialCellsCount()); }
    }

    private IEnumerable<Q> GetInitialSubdivision()
    {
      var array = new long[myDimension];
      for (int i = 0; i < myDimension; i++)
      {
        array[i] = 0;
      }

      long limit = mySubdivision[myDimension - 1];
      while (array[myDimension - 1] < limit)
      {
        yield return myInh.Create(array);
        array[0]++;
        for (int i = 0; i < myDimension - 1; i++)
        {
          if (array[i] >= mySubdivision[i])
          {
            array[i] = 0;
            array[i + 1]++;
          }
        }
      }
    }

    public ICellCoordinateSystemConverter<Q, Q> Subdivide(long[] division)
    {
      var toSystem = myInh.SubdividedCoordinateSystem(division);
      return CreateSubdivideConverter(myInh, toSystem, division);
    }

    protected virtual ICellCoordinateSystemConverter<Q, Q> CreateSubdivideConverter(TInh from, TInh to, long[] division)
    {
      return new IntegerCoordinateCellConverter<TInh, Q>(from, to, division);
    }

    public ICellCoordinateSystemProjector<Q> Project(long[] factor)
    {
      TInh subdivide = myInh.ProjectedCoordinateSystem(factor);
      if (subdivide == null)
        return null;
      return new IntegerCoordinateCellProjector<TInh, Q>(myInh, subdivide, factor);
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

    private long GetInitialCellsCount()
    {
      return mySubdivision.Aggregate<long, long>(1, (current, l) => current*l);
    }

    public override bool Equals(object obj)
    {
      if (obj is IntegerCoordinateSystemBase<TInh, Q>)
      {
        var inh = (IntegerCoordinateSystemBase<TInh, Q>) obj;
        if (inh.myDimension != myDimension)
          return false;

        for(int i=0; i<myDimension; i++)
        {
          if (myAreaLeftPoint[i] != inh.myAreaLeftPoint[i])
            return false;
          if (mySubdivision[i] != inh.mySubdivision[i])
            return false;
          if (myCellSize[i] != inh.myCellSize[i])
            return false;
        }
        return true;        
      } 
      return false;      
    }

    public override int GetHashCode()
    {
      long v = 0;
      for (int i = 0; i < myDimension; i++)
        v += mySubdivision[i];

      return myDimension + ((int)v) * 97 + ((int)(v>>32)) * 131;
    }

    protected long[] GetSubdividedFactor(long[] division)
    {
      var div = new long[myDimension];
      for (int i = 0; i < div.Length; i++)
      {
        div[i] = mySubdivision[i]*division[i];
      }
      return div;
    }

    protected long[] GetProjectedFactor(long[] project)
    {
      var div = new long[myDimension];
      for (int i = 0; i < div.Length; i++)
      {
        div[i] = mySubdivision[i]/project[i];
        if (div[i] == 0)
          return null;
      }
      return div;
    }

    private double[] FillArrayFromCell(double cellSizeFactor)
    {
      var eps = new double[myDimension];
      for (int i = 0; i < myDimension; i++)
        eps[i] = cellSizeFactor * myCellSize[i];
      return eps;
    }

    private double[] FillArray(double cellSizeFactor)
    {
      return cellSizeFactor.Fill(myDimension);
    }

    public virtual IRadiusProcessor<Q> CreateRadiusProcessor()
    {
      return new RadiusProcessor<TInh, Q>(myInh);
    }

    public virtual IRectProcessor<Q> CreateRectProcessor(double[] eps)
    {
      return new RectProcessor<TInh, Q>(myInh, eps);
    }

    public IRectProcessor<Q> CreateRectProcessor(double cellSizeFactor)
    {
      return CreateRectProcessor(FillArrayFromCell(cellSizeFactor));
    }

    public virtual IPointProcessor<Q> CreatePointProcessor()
    {
      return new PointProcessor<TInh, Q>(myInh);
    }

    public IPointProcessor<Q> CreateOverlapedPointProcessor(double cellSizePercent)
    {
      return CreateOverlapedPointProcessor(FillArray(cellSizePercent));
    }

    public virtual IPointProcessor<Q> CreateOverlapedPointProcessor(double[] cellSizePercent)
    {
      return new OverlappingProcessor<TInh, Q>(myInh, cellSizePercent);
    }

    private static string SaveMarker()
    {
      return "INTEGER_COORDINATE_BASE";
    }

    public void Save(IBinaryWriter writer, IEnumerable<Q> coords)
    {
      writer.WriteString(SaveMarker());

      foreach (var q in coords)
      { 
        writer.WriteInt(0);
        for(var i=0; i<myDimension; i++)
        {
          writer.WriteLong(q.GetCoordinate(i));
        }
      }
      writer.WriteInt(1);        
    }

    public IEnumerable<Q> Load(IBinaryReader reader)
    {
      if (SaveMarker() != reader.ReadString())
        throw new ArgumentException("Failed to read. Marker is expected");

      while(reader.ReadInt() == 0)
      {
        var data = new long[myDimension];
        for(var i=0; i<myDimension;i++)
        {
          reader.Read(out data[i]); 
        }
        yield return myInh.Create(data);
      }      
    }

    public void DoGeneric(ICellCoordinateWith with)
    {
      with.With(myInh);
    }

  }
}