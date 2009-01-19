using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  public class IkedaFunction : Function<double>, IFunction<double>, IDetDiffFunction<double>
  {
    public IkedaFunction() : base(2)
    {
    }

    public void Evaluate()
    {
      var x = Input[0];
      var y = Input[1];

      var t = 0.4 - 6.0/(1.0 + x*x + y*y);
      var cost = Math.Cos(t);
      var sint = Math.Sin(t);
      Output[0] = 2.0 - 0.9*(x*cost - y*sint);
      Output[1] =       0.9*(x*sint + y*cost);      
    }

    public double Evaluate(double[] data)
    {
      double x = data[0];
      double y = data[1];

      var xxyy = 1.0 + x*x + y*y;

      var t = 0.4 - 6.0/xxyy;
      var _t = 6.0/(xxyy*xxyy);
      var tx = _t*2*x;
      var ty = _t*2*y;
      var cost = Math.Cos(t);
      var sint = Math.Sin(t);

      var fx_x = -0.9*(cost - x*sint*tx - y*cost*tx);
      var fx_y = -0.9*(-x*sint*ty - sint - y*cost*ty);
      var fy_x = 0.9*(sint + x*cost*tx - y*sint*tx);
      var fy_y = 0.9*(x*cost*ty + cost - y*sint*ty);

      var r = fx_x*fy_y - fx_y*fy_x;
//      Console.Out.WriteLine("x, y => r: {0}, {1} => {2}", x, y, r);
      return r;
    }
  }

  [Serializable]
  public class IkedaParameters : ISystemInfoParameters {}
}
