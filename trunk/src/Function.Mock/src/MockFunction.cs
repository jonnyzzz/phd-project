using DSIS.Core.System;
using DSIS.Function.Predefined;

namespace DSIS.Function.Mock
{
  public delegate void ComputeFunction<T>(T[] ins, T[] outs);

  public delegate T ComputeOneFunction<T>(T ins);

  public class MockFunction<T> : FunctionBase<T>, IFunction<T>
  {
    private readonly ComputeFunction<T> myCompute;

    public MockFunction(int dimension, ComputeFunction<T> compute) : base(dimension, null)
    {
      myCompute = compute;
    }
    
    public MockFunction(int dimension, ComputeOneFunction<T> compute) : base(dimension, null)
    {
      myCompute = delegate(T[] ins, T[] outs) { outs[0] = compute(ins[0]); };
    }

    public override void Evaluate()
    {
      myCompute(Input, Output);
    }
  }
}