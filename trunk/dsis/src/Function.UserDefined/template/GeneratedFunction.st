using DSIS.Core.System;
using DSIS.Core.Ioc;
using DSIS.Function.Predefined;
using DSIS.Function.UserDefined;


namespace DSIS.Function.UserDefined.Generated 
{
  public class AFunction : Function<double>, IFunction<double>
  {
    public AFunction( )
      : base( $Dimension$ )
    {
    } 

    $predefines$

    public void Evaluate()
    {
      $DimensionIt:{
        var x$it.N$ = Input[$it.P$];
        double f$it.N$;
      }$

      //User code
      //_________________________________________
      $userCode$
      //_________________________________________ 
      //End of User code

      $DimensionIt:{
        Output[$it.P$] = f$it.N$;
      }$
    }
  }

  [GeneratedImplementationArrtubute]
  [NoInheritContainerAttribute]
  public class AFunctionInfo : DoubleSystemInfoBase, ISystemInfoMarker
  {    
    public AFunctionInfo() : base($Dimension$)
    {
    }

    public override string PresentableName
    {
      get { return $PresentableName$; }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new AFunction();
    }

    public override SystemType Type
    {
      get { return $SystemType$; }
    }
  }
}