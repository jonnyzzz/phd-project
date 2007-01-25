using System;
using DSIS.Core.System;
using DSIS.Core.System.Tree;
using DSIS.Function.Predefined;
using NUnit.Framework;

namespace DSIS.Function.Mock
{
  public class MockSystemInfo<TType> : ISystemInfo
  {
    private ComputeFunction<TType> myFunc;
    private ISystemSpace mySystemSpace;

    private static void AssertType<T>()
    {
      Assert.AreEqual(typeof(TType), typeof(T));
    }

    public MockSystemInfo(ComputeFunction<TType> func, ISystemSpace systemSpace)
    {
      myFunc = func;
      mySystemSpace = systemSpace;
    }

    public IFunction<T> GetFunction<T>(int iteration)
    {
      AssertType<T>();
      return (IFunction<T>) new Function<TType>(mySystemSpace.Dimension, myFunc);
    }

    public IFunction<T> GetDerivateFunction<T>(int iteration, int derivatePower)
    {
      throw new NotImplementedException();
    }

    public IFunction<T> GetDerivateFunction<T>(int iteration, int[] unsimmetricDerivate)
    {
      throw new NotImplementedException();
    }

    public Q ProcessFunctionTree<Q>(IFunctionTreeVisitor<Q> visitor)
    {
      throw new NotImplementedException();
    }

    public Type[] SupportedFunctionTypes
    {
      get { return new Type[] {typeof (TType)}; }
    }

    public ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
    }
  }

  public delegate void ComputeFunction<T>(T[] ins, T[] outs);
  public delegate T ComputeOneFunction<T>(T ins);

  internal class Function<T> : FunctionBase<T>, IFunction<T>
  {
    private ComputeFunction<T> myCompute;

    public Function(int dimension, ComputeFunction<T> compute) : base(dimension, null)
    {
      myCompute = compute;
    }

    public override void Evaluate()
    {
      myCompute(Input, Output);
    }
  }
}
