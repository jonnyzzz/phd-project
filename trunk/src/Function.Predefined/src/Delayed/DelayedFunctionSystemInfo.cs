/*
 * Created by: 
 * Created: 26 ÿםגאנÿ 2007 ד.
 */

using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined.Delayed
{
  public class DelayedFunctionSystemInfo : DoubleSystemInfoBase
  {
    private double myA;

    public DelayedFunctionSystemInfo(ISystemSpace systemSpace, double a) : base(systemSpace)
    {
      myA = a;
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new DelayedFunction(myA);
    }

    protected override IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}