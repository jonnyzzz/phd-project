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
      internal readonly double myCellSizeHalfL$it$;
      internal readonly double myCellSizeL$it$;    
      internal readonly double myAreaLeftPointL$it$;    
      internal readonly long mySubdivisionL$it$;
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
    internal long ToInternalL$it$(double point)
    {
      return Ceil((point - myAreaLeftPointL$it$)/ myCellSizeL$it$);
    }
    internal double ToExternalL$it$(long pt)
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

	$DimensionIt:{
    internal bool IntersectsL$it$(long l)
    {      
      return l >= 0 && l < mySubdivisionL$it$;     
    }
    }$

    public bool Intersects(long l, int axis)
    {
      switch(axis)
      {
        $DimensionIt:{
        case $it$:
          return IntersectsL$it$(l);
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
    
    public void DoGeneric(IIntegerCoordinateSystemWith with)
    {
      with.Do<IntegerCoordinateSystem, IntegerCoordinate>(this);
    } 
    
    public int Dimension
    {
      get { return $Dimension$; }
    }
    
    public override IRadiusProcessor<IntegerCoordinate> CreateRadiusProcessor()
    {
      return new RadiusProcessor(this);
    }

    public override IRectProcessor<IntegerCoordinate> CreateRectProcessor(double[] eps)
    {
      return new RectProcessor(this, eps);
    }        
    
    public override IPointProcessor<IntegerCoordinate> CreateOverlapedPointProcessor(double[] cellSizePercent)
    {
      return new OverlappingProcessor(this, cellSizePercent);
    }
  }

  [EqualityComparer(typeof(IntegerCoordinateEqualityComparer))]
  public class IntegerCoordinate : IIntegerCoordinate
  {
    $DimensionIt:{
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
    
  public class IntegerCoordinateSystemFactory : IIntegerCoordinateFactoryEx
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
    
    public IIntegerCoordinateSystemInfo Create(ISystemSpace space, long[] subd)
    {
      return new IntegerCoordinateSystem(space, subd);
    }
  }
  
  public class RectProcessorBase
  {
    $DimensionIt:{
    protected long myLeft$it$;
    protected long myRight$it$;
    protected long myPoint$it$;
    }$
        
    protected readonly IntegerCoordinateSystem myCoordinateSystem;
    protected readonly ISystemSpace mySystemSpace;

    public RectProcessorBase(IntegerCoordinateSystem coordinateSystem)
    {
      myCoordinateSystem = coordinateSystem;
      mySystemSpace = myCoordinateSystem.SystemSpace;            
    }

    protected IEnumerable<IntegerCoordinate> Enumerate()
    {      
      while (true)
      {
        yield return myCoordinateSystem.Create($DimensionIt:{myPoint$it$};separator=", "$);

        myPoint0++;
                
        $DimensionItNext:{
          if (myPoint$it.First$ > myRight$it.First$)
          {            
            $if(it.Second)$
              myPoint$it.First$ = myLeft$it.First$;
              myPoint$it.Second$++;              
            $else$
              break;
            $endif$
          }
          else continue;
        }$
      }
    }
  }
  
  internal sealed class RectProcessor : RectProcessorBase, IRectProcessor<IntegerCoordinate>    
  {
    $DimensionIt:{
    private readonly double myEps$it$;
    }$

    public RectProcessor(IntegerCoordinateSystem coordinateSystem, double[] eps) : base(coordinateSystem)
    {
      $DimensionIt:{
      myEps$it$ = eps[$it$];
      }$
    }

    public IEnumerable<IntegerCoordinate> ConnectCellToRect(double[] left, double[] right)
    {
      if (!mySystemSpace.ContainsRect(left, right))
        return EmptyArray<IntegerCoordinate>.Instance;

      $DimensionIt:{      
        myLeft$it$ = myCoordinateSystem.ToInternalL$it$(left[$it$] - myEps$it$);
        if (myLeft$it$ < 0)
          myLeft$it$ = 0;

        myRight$it$ = myCoordinateSystem.ToInternalL$it$(right[$it$] + myEps$it$);
        if (myRight$it$ > myCoordinateSystem.mySubdivisionL$it$)
          myRight$it$ = myCoordinateSystem.mySubdivisionL$it$ - 1;

        myPoint$it$ = myLeft$it$;
      }$

      return Enumerate();
    }
  }
  
  internal sealed class RadiusProcessor : RectProcessorBase, IRadiusProcessor<IntegerCoordinate>
  {
    public RadiusProcessor(IntegerCoordinateSystem coordinateSystem) : base(coordinateSystem)
    {
    }

    public IEnumerable<IntegerCoordinate> ConnectCellToRadius(double[] point, double[] radius)
    {
      if (!mySystemSpace.Contains(point))
        return EmptyArray<IntegerCoordinate>.Instance;

      $DimensionIt:{
        myLeft$it$ = myCoordinateSystem.ToInternalL$it$(point[$it$] - radius[$it$]);
        if (myLeft$it$ < 0)
          myLeft$it$ = 0;

        myRight$it$ = myCoordinateSystem.ToInternalL$it$(point[$it$] + radius[$it$]);
        if (myRight$it$ > myCoordinateSystem.mySubdivisionL$it$)
          myRight$it$ = myCoordinateSystem.mySubdivisionL$it$ - 1;

        myPoint$it$ = myLeft$it$;
      }$

      return Enumerate();
    }
  }
  
  
  internal sealed class OverlappingProcessor : IPointProcessor<IntegerCoordinate>
  {
    private readonly IntegerCoordinateSystem myCoordinateSystem;
    $DimensionIt:{
    private long myPoint_$it$;
    private long myPoint2_$it$;    
    private long myZeros$it$;
    private long myOnes$it$;
    private double myOLeft$it$;
    private double myORight$it$;
    }$

    public OverlappingProcessor(IntegerCoordinateSystem coordinateSystem, double[] percent)
    {
      myCoordinateSystem = coordinateSystem;

      $DimensionIt:{
        myZeros$it$ = 0;
        myOnes$it$ = 1;
        myOLeft$it$ = myCoordinateSystem.myCellSizeL$it$ * percent[$it$];
        myORight$it$ = myCoordinateSystem.myCellSizeL$it$ * (1 - percent[$it$]);
      }$
    }

    public IEnumerable<IntegerCoordinate> AddPoint(double[] value)
    {
      bool iter = false;
      bool intersects = true;
      $DimensionIt:{ {     
        double v = value[$it$];
        myPoint_$it$ = myCoordinateSystem.ToInternalL$it$(v);
                
        intersects &= myCoordinateSystem.IntersectsL$it$(myPoint_$it$);
        
        if (!intersects && (myPoint_$it$ < -1 || myPoint_$it$ > myCoordinateSystem.mySubdivisionL$it$ + 1))
			yield break;
		
		double tmp = v - myCoordinateSystem.ToExternalL$it$(myPoint_$it$);
        if (tmp < myOLeft$it$)
        {
          myPoint2_$it$ = -1;
          iter = true;
        }
        else if (tmp > myORight$it$)
        {
          myPoint2_$it$ = 1;
          iter = true;
        }
        else
          myPoint2_$it$ = 0;		
      } }$
            
      if (intersects)
		yield return myCoordinateSystem.Create($DimensionIt:{myPoint_$it$};separator=", "$);
      
      if (iter) {
        $BoxIt:{ {
          if (myPoint2_$it.First$ != 0)
          {
			  $if(it.Second)$
				myPoint_$it.First$ += myPoint2_$it.First$;
			  $else$
				myPoint_$it.First$ -= myPoint2_$it.First$;
			  $endif$

	  		  if (myCoordinateSystem.IntersectsL$it.First$(myPoint_$it.First$))
				yield return myCoordinateSystem.Create($DimensionIt:{myPoint_$it$};separator=", "$);          
		  }		  
        } }$     
      }             
    }
  }  
}