/*
 * Created by: 
 * Created: 26 ������ 2007 �.
 */

using System;
using DSIS.Core.System;

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
}