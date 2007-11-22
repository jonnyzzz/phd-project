using DSIS.Core.System;

namespace DSIS.Function.Predefined.Henon
{
  public class HenonFunctionDerivate : Function<double>, IFunction<double>
  {
    private readonly double myA;

    public HenonFunctionDerivate(double a) : base(2, new FunctionIO<double>(), new FunctionIO<double>())
    {
      myA = a;
    }

    public void Evaluate()
    {
      Output[0] = 1 - myA*Input[0]*Input[0] + 0.3*Input[1];
      Output[1] = Input[0];

      Derivates[0].Output[0] = -2*myA*Input[0];
      Derivates[0].Output[1] = 0.3;
      Derivates[1].Output[0] = 1;
      Derivates[1].Output[1] = 0;
    }
  }
}