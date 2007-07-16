using System;
using System.Collections.Generic;
using DSIS.IntegerCoordinates;
using DSIS.Utils;
using DSIS.Core.System;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Generated;

namespace DSIS.Generated	
{
  public class IntegerCoordinateSystem : 
    IntegerCoordinateSystemBase<IntegerCoordinateSystem, IntegerCoordinate>, 
    IProcessorFactory<IntegerCoordinate>, 
    IEXIntegerCoordinateSystemBase<IntegerCoordinateSystem, IntegerCoordinate>
  {
  
    $DimensionIt:{
      private readonly double myCellSizeHalfL$it$;
      private readonly double myCellSizeL$it$;    
      private readonly double myAreaLeftPointL$it$;    
      private readonly long mySubdivisionL$it$;
    }$

    public IntegerCoordinateSystem(ISystemSpace systemSpace, long[] subdivision) : base(systemSpace, subdivision)
    {
      $DimensionIt:{
		myCellSizeL$it$ = myCellSize[$it$];
        myCellSizeHalfL$it$ = myCellSizeHalf[$it$];        
        myAreaLeftPointL$it$ = myAreaLeftPoint[$it$];      
        mySubdivisionL$it$ = mySubdivision[$it$];
      }$      
    }

    public IntegerCoordinateSystem(ISystemSpace systemSpace) : this(systemSpace, systemSpace.InitialSubdivision)
    {
    }

    public new long ToInternal(double point, int i)
    {
      switch(i)
      {
      $DimensionIt:{
        case $it$:
          return ToInternalL$it$(point);
      }$
        default:
          throw new OutOfMemoryException();
      }      
    }

	$DimensionIt:{
    private long ToInternalL$it$(double point)
    {
      return Ceil((point - myAreaLeftPointL$it$)/ myCellSizeL$it$);
    }
    private double ToExternalL$it$(long pt)
    {
      return myAreaLeftPointL$it$ + myCellSizeL$it$ * pt;
    }
    }$

    public new double ToExternal(long pt, int i)
    {
      switch(i)
      {
        $DimensionIt:{
        case $it$:
          return ToExternalL$it$(pt);
        }$        
        default:
          throw new OutOfMemoryException();
      }
    }
    
    public void TopLeftPoint(IntegerCoordinate point, double[] output)
    {
      $DimensionIt:{
		output[$it$] = ToExternalL$it$(point.l$it$);
      }$
    }

    public void CenterPoint(IntegerCoordinate point, double[] output)
    {
	  $DimensionIt:{
		output[$it$] = ToExternalL$it$(point.l$it$) + myCellSizeHalfL$it$;
      }$
    }

    public bool Intersects(long l, int axis)
    {
      switch(axis)
      {
        $DimensionIt:{
        case $it$:
          return l >= 0 && l < mySubdivisionL$it$;
        }$
        default:
          return false;
      }
    }

    public IntegerCoordinate Create(params long[] param)
    {
      return new IntegerCoordinate($DimensionIt:{ param[$it$] }; separator=","$);
    }

    public IntegerCoordinate Create($DimensionIt:{ long l$it$ }; separator=","$)
    {
      return new IntegerCoordinate($DimensionIt:{ l$it$ }; separator=","$);        
    }

    public IProcessorFactory<IntegerCoordinate> ProcessorFactory
    {
      get { return this; }
    }

    public IntegerCoordinate FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))
        return null;

	  $DimensionIt:{
		long l$it$ = ToInternalL$it$(point[$it$]);
	  }$
      
      return Create($DimensionIt:{ l$it$ }; separator=","$	);
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
  }

  [EqualityComparer(typeof(IntegerCoordinateEqualityComparer))]
  public class IntegerCoordinate : IIntegerCoordinate<IntegerCoordinate>
  {
    $DimensionIt:	{
    public readonly long l$it$;
    }$

    public IntegerCoordinate($DimensionIt:{long l$it$}; separator=","$)
    {
      $DimensionIt:{
        this.l$it$ = l$it$;
      }$      
    }

    public IEqualityComparer<IntegerCoordinate> Comparer
    {
      get { return IntegerCoordinateEqualityComparer.INSTANCE; }
    }

    public long GetCoordinate(int index)
    {
      switch(index)
      {
        $DimensionIt: {
        case $it$:
          return l$it$;
        }$        
        default:
          throw new IndexOutOfRangeException();
      }
    }

    public int Dimension
    {
      get { return $Dimension$; }
    }


    public override string ToString()
    {
      return string.Format("[ $DimensionIt:{ {$it$} }; separator=","$ ]", $DimensionIt:{l$it$}; separator=","$);
    }
  }

  public class IntegerCoordinateEqualityComparer : IEqualityComparer<IntegerCoordinate>
  {
    public static readonly IntegerCoordinateEqualityComparer INSTANCE = new IntegerCoordinateEqualityComparer();

    public bool Equals(IntegerCoordinate x, IntegerCoordinate y)
    {
      return $DimensionIt:{x.l$it$ == y.l$it$};separator="&&"$;      
    }

    public int GetHashCode(IntegerCoordinate obj)
    {
      return (int) ( $DimensionItPair:{ obj.l$it.First$ * $it.Second$ }; separator=" + "$ ) & 0x7fffff;
    }
  }
    
  public class IntegerCoordinateSystemFactory : IIntegerCoordinateFactory
  {    
    public void WithIntegerCoordinateSystem(IIntegerCoordinateCallback cb)
    {
      cb.Do<IntegerCoordinateSystem, IntegerCoordinate>(
        delegate(ISystemSpace ss, long[] subd) { return new IntegerCoordinateSystem(ss,subd);
        });
    }

    public Type System
    {
      get { return typeof(IntegerCoordinateSystem); }
    }

    public Type Coordinate
    {
      get { return typeof (IntegerCoordinate); }
    }
  }

   
}