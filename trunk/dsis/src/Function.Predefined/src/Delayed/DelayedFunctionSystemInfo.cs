/*
 * Created by: 
 * Created: 26 ÿםגאנÿ 2007 ד.
 */

using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Delayed
{
  public class DelayedFunctionSystemInfo : DoubleSystemInfoBase
  {
    private readonly double myA;

    public DelayedFunctionSystemInfo(double a) : base(2)
    {
      myA = a;
    }

    public override string PresentableName
    {
      get { return string.Format("Delayed a={0}", myA); }
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

  [UsedBySpring]
  public class DelayedFactory : DoubleParametersSystemInfoFactoryBase
  {
    public DelayedFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base("Delayed", 1, delegate(double[] paramz)
                                                         {
                                                           return new DelayedFunctionSystemInfo(paramz[0]);
                                                         }, parser, factory)
    {
    }
  }
}