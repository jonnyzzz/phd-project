using DSIS.Core.System;
using DSIS.Function.Predefined;

public class AFunction : Function<double>, IFunction<double>
{
  public AFunction(double a)
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
