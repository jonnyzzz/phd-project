using DSIS.Core.System;

namespace DSIS.Function.Predefined.Chua
{
  public class ChuaFunction2 : Function<double>, IFunction<double>
  {
    private readonly double myA;
    private readonly double myB;
    private readonly double myM0;
    private readonly double myM1;

    public ChuaFunction2(ChuaOptions2 opts)
      : base(3)
    {
      myA = opts.A;
      myB = opts.B;
      myM1 = opts.M0;
      myM0 = opts.M1;
    }

    public void Evaluate()
    {
      var x = Input[0];
      var y = Input[1];
      var z = Input[2];

      Output[0] = myA *( y - myM0*x - 1.0/3.0*myM1*x*x*x);
      Output[1] = x - y  + z;
      Output[2] = - myB * y;
    }
  }
}