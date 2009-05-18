using System;
using System.Collections.Generic;
using DSIS.IntegerCoordinates;
using DSIS.Utils;
using DSIS.Core.System;
using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Generated;

namespace DSIS.Generated	
{
  public sealed class IntegerCoordinateSystem$Key$ : 
    IntegerCoordinateSystemBase<IntegerCoordinateSystem$Key$, IntegerCoordinate$Key$>, 
    IProcessorFactory<IntegerCoordinate$Key$>, 
    IEXIntegerCoordinateSystemBase<IntegerCoordinateSystem$Key$, IntegerCoordinate$Key$>
  {
  
    $DimensionIt:{
      internal readonly double myCellSizeHalfL$it$;
      internal readonly double myCellSizeL$it$;    
      internal readonly double myAreaLeftPointL$it$;    
      internal readonly long mySubdivisionL$it$;
    }$

    public IntegerCoordinateSystem$Key$(ISystemSpace systemSpace, long[] subdivision) : base(systemSpace, subdivision)
    {
      $DimensionIt:{
		myCellSizeL$it$ = myCellSize[$it$];
        myCellSizeHalfL$it$ = myCellSizeHalf[$it$];        
        myAreaLeftPointL$it$ = myAreaLeftPoint[$it$];      
        mySubdivisionL$it$ = mySubdivision[$it$];
      }$      
    }

    public IntegerCoordinateSystem$Key$(ISystemSpace systemSpace) : this(systemSpace, systemSpace.InitialSubdivision)
    {
    }

    public bool IsGenerated 
    { 
      get { return true; }
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
          throw new ArgumentException();
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
          throw new ArgumentException();
      }
    }
    
    public void TopLeftPoint(IntegerCoordinate$Key$ point, double[] output)
    {
      $DimensionIt:{
		output[$it$] = ToExternalL$it$(point.l$it$);
      }$
    }

    public void CenterPoint(IntegerCoordinate$Key$ point, double[] output)
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

    public IntegerCoordinate$Key$ Create(params long[] param)
    {
      return new IntegerCoordinate$Key$($DimensionIt:{ param[$it$] }; separator=","$);
    }

    public IntegerCoordinate$Key$ Create($DimensionIt:{ long l$it$ }; separator=","$)
    {
      return new IntegerCoordinate$Key$($DimensionIt:{ l$it$ }; separator=","$);        
    }

    public IProcessorFactory<IntegerCoordinate$Key$> ProcessorFactory
    {
      get { return this; }
    }

    public IntegerCoordinate$Key$ FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))
        return null;

	  $DimensionIt:{
		long l$it$ = ToInternalL$it$(point[$it$]);
	  }$
      
      return Create($DimensionIt:{ l$it$ }; separator=","$	);
    }

    public IntegerCoordinateSystem$Key$ SubdividedCoordinateSystem(long[] division)
    {
      return new IntegerCoordinateSystem$Key$(SystemSpace, GetSubdividedFactor(division));
    }
    
    public IntegerCoordinateSystem$Key$ ProjectedCoordinateSystem(long[] division)
    {
      long[] factor = GetProjectedFactor(division);
      return factor != null ? new IntegerCoordinateSystem$Key$(SystemSpace, factor) : null;
    }       
    
    public void DoGeneric(IIntegerCoordinateSystemWith with)
    {
      with.Do<IntegerCoordinateSystem$Key$, IntegerCoordinate$Key$>(this);
    } 
    
    public int Dimension
    {
      get { return $Dimension$; }
    }
    
    public override IRadiusProcessor<IntegerCoordinate$Key$> CreateRadiusProcessor()
    {
      return new RadiusProcessor$Key$(this);
    }

    public override IRectProcessor<IntegerCoordinate$Key$> CreateRectProcessor(double[] eps)
    {
      return new RectProcessor$Key$(this, eps);
    }        
    
    public override IPointProcessor<IntegerCoordinate$Key$> CreateOverlapedPointProcessor(double[] cellSizePercent)
    {
      return new OverlappingProcessor$Key$(this, cellSizePercent);
    }
    
    protected override ICellCoordinateSystemConverter<IntegerCoordinate$Key$, IntegerCoordinate$Key$> CreateSubdivideConverter(IntegerCoordinateSystem$Key$ from, IntegerCoordinateSystem$Key$ to, long[] division)
    {
      return new IntegerCoordinateCellConverter$Key$(from, to, division);
    }
  }

  [EqualityComparer(typeof(IntegerCoordinateEqualityComparer$Key$))]
  public sealed class IntegerCoordinate$Key$ : IIntegerCoordinate
  {
    $DimensionIt:{
    public readonly long l$it$;
    }$

    public IntegerCoordinate$Key$($DimensionIt:{long l$it$}; separator=","$)
    {
      $DimensionIt:{
        this.l$it$ = l$it$;
      }$      
    }

    public IEqualityComparer<IntegerCoordinate$Key$> Comparer
    {
      get { return IntegerCoordinateEqualityComparer$Key$.INSTANCE; }
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

  public sealed class IntegerCoordinateEqualityComparer$Key$ : IEqualityComparer<IntegerCoordinate$Key$>
  {
    public static readonly IntegerCoordinateEqualityComparer$Key$ INSTANCE = new IntegerCoordinateEqualityComparer$Key$();

    public bool Equals(IntegerCoordinate$Key$ x, IntegerCoordinate$Key$ y)
    {
      return $DimensionIt:{x.l$it$ == y.l$it$};separator="&&"$;      
    }

    public int GetHashCode(IntegerCoordinate$Key$ obj)
    {
      return (int) ( $DimensionItPair:{ obj.l$it.First$ * $it.Second$ }; separator=" + "$ ) & 0x7fffff;
    }
  }
    
  public sealed class IntegerCoordinateSystemFactory$Key$ : IIntegerCoordinateFactoryEx
  {    
    public void WithIntegerCoordinateSystem(IIntegerCoordinateCallback cb)
    {
      cb.Do<IntegerCoordinateSystem$Key$, IntegerCoordinate$Key$>(
        delegate(ISystemSpace ss, long[] subd) { return new IntegerCoordinateSystem$Key$(ss,subd);
        });
    }

    public Type System
    {
      get { return typeof(IntegerCoordinateSystem$Key$); }
    }

    public Type Coordinate
    {
      get { return typeof (IntegerCoordinate$Key$); }
    }
    
    public IIntegerCoordinateSystem Create(ISystemSpace space, long[] subd)
    {
      return new IntegerCoordinateSystem$Key$(space, subd);
    }
  }
  
  
  internal sealed class IntegerCoordinateCellConverter$Key$ : ICellCoordinateSystemMultiplyConverter<IntegerCoordinate$Key$> 
  {
    private readonly IntegerCoordinateSystem$Key$ myFromSystem;
    private readonly IntegerCoordinateSystem$Key$ myToSystem;
    
    private readonly long[] myDivision; 
    
    $DimensionIt:{
      private readonly long myDivision$it$;
    }$
    
    public IntegerCoordinateCellConverter$Key$(IntegerCoordinateSystem$Key$ fromSystem,
                                               IntegerCoordinateSystem$Key$ toSystem, 
                                               long[] division)
    {
      myFromSystem = fromSystem;
      myToSystem = toSystem;
      myDivision = division;
      
      $DimensionIt:{
         myDivision$it$=division[$it$];
      }$
    }

    public long[] Division
    {
      get { return myDivision; }
    }

    public ICellCoordinateSystem<IntegerCoordinate$Key$> FromSystem
    {
      get { return myFromSystem; }
    }

    public IEnumerable<IntegerCoordinate$Key$> Subdivide(IntegerCoordinate$Key$ coordinate)
    {
      $DimensionIt:{
        long min$it$ = coordinate.l$it$ * myDivision$it$;
        long max$it$ = min$it$ + myDivision$it$;
      }$
      
      $DimensionIt:{
        for(long i$it$=min$it$; i$it$ < max$it$ ; i$it$++)
      }$
      {
        yield return myToSystem.Create($DimensionIt:{i$it$}; separator=", "$);
      }      
    }

    public ICellCoordinateSystemConverter<IntegerCoordinate$Key$, IntegerCoordinate$Key$> Clone()
    {
      return new IntegerCoordinateCellConverter$Key$(myFromSystem, myToSystem, myDivision);
    }

    public ICellCoordinateSystem<IntegerCoordinate$Key$> ToSystem
    {
      get { return myToSystem; }
    }
  }
  
  public class RectProcessorBase$Key$
  {
    $DimensionIt:{
    protected long myLeft$it$;
    protected long myRight$it$;
    }$
        
    protected readonly IntegerCoordinateSystem$Key$ myCoordinateSystem;
    protected readonly ISystemSpace mySystemSpace;

    public RectProcessorBase$Key$(IntegerCoordinateSystem$Key$ coordinateSystem)
    {
      myCoordinateSystem = coordinateSystem;
      mySystemSpace = myCoordinateSystem.SystemSpace;            
    }

    protected IEnumerable<IntegerCoordinate$Key$> Enumerate()
    {             
	  $DimensionIt:{
		for(long myPoint$it$=myLeft$it$; myPoint$it$ <= myRight$it$; myPoint$it$++)
      }$
		yield return myCoordinateSystem.Create($DimensionIt:{myPoint$it$};separator=", "$);        
    }
  }
  
  internal sealed class RectProcessor$Key$ : RectProcessorBase$Key$, IRectProcessor<IntegerCoordinate$Key$>    
  {
    $DimensionIt:{
    private readonly double myEps$it$;
    }$

    public RectProcessor$Key$(IntegerCoordinateSystem$Key$ coordinateSystem, double[] eps) : base(coordinateSystem)
    {
      $DimensionIt:{
      myEps$it$ = eps[$it$];
      }$
    }

    public IEnumerable<IntegerCoordinate$Key$> ConnectCellToRect(double[] left, double[] right)
    {
      if (!mySystemSpace.ContainsRect(left, right))
        return EmptyArray<IntegerCoordinate$Key$>.Instance;

      $DimensionIt:{      
        myLeft$it$ = myCoordinateSystem.ToInternalL$it$(left[$it$] - myEps$it$);
        if (myLeft$it$ < 0)
          myLeft$it$ = 0;

        myRight$it$ = myCoordinateSystem.ToInternalL$it$(right[$it$] + myEps$it$);
        if (myRight$it$ > myCoordinateSystem.mySubdivisionL$it$)
          myRight$it$ = myCoordinateSystem.mySubdivisionL$it$ - 1;
      }$

      return Enumerate();
    }
  }
  
  internal sealed class RadiusProcessor$Key$ : RectProcessorBase$Key$, IRadiusProcessor<IntegerCoordinate$Key$>
  {
    public RadiusProcessor$Key$(IntegerCoordinateSystem$Key$ coordinateSystem) : base(coordinateSystem)
    {
    }

    public IEnumerable<IntegerCoordinate$Key$> ConnectCellToRadius(double[] point, double[] radius)
    {
      if (!mySystemSpace.Contains(point))
        return EmptyArray<IntegerCoordinate$Key$>.Instance;

      $DimensionIt:{
        myLeft$it$ = myCoordinateSystem.ToInternalL$it$(point[$it$] - radius[$it$]);
        if (myLeft$it$ < 0)
          myLeft$it$ = 0;

        myRight$it$ = myCoordinateSystem.ToInternalL$it$(point[$it$] + radius[$it$]);
        if (myRight$it$ > myCoordinateSystem.mySubdivisionL$it$)
          myRight$it$ = myCoordinateSystem.mySubdivisionL$it$ - 1;
      }$

      return Enumerate();
    }
  }
  
  
  internal sealed class OverlappingProcessor$Key$ : IPointProcessor<IntegerCoordinate$Key$>
  {
    private readonly IntegerCoordinateSystem$Key$ myCoordinateSystem;
    $DimensionIt:{
    private long myPoint_$it$;
    private long myPoint2_$it$;    
    private long myZeros$it$;
    private long myOnes$it$;
    private double myOLeft$it$;
    private double myORight$it$;
    }$

    public OverlappingProcessor$Key$(IntegerCoordinateSystem$Key$ coordinateSystem, double[] percent)
    {
      myCoordinateSystem = coordinateSystem;

      $DimensionIt:{
        myZeros$it$ = 0;
        myOnes$it$ = 1;
        myOLeft$it$ = myCoordinateSystem.myCellSizeL$it$ * percent[$it$];
        myORight$it$ = myCoordinateSystem.myCellSizeL$it$ * (1 - percent[$it$]);
      }$
    }

    public IEnumerable<IntegerCoordinate$Key$> AddPoint(double[] value)
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