using System;
using DSIS.Core.System;
using DSIS.Core.System.Tree;
using NUnit.Framework;

namespace DSIS.Function.Mock
{
  public class MockSystemInfo<TType> : ISystemInfo
  {
    private readonly ComputeFunction<TType> myFunc;
    private readonly ISystemSpace mySystemSpace;

    public MockSystemInfo(ComputeFunction<TType> func, ISystemSpace systemSpace)
    {
      myFunc = func;
      mySystemSpace = systemSpace;
    }

    public IFunction<T> GetDerivateFunction<T>(int derivatePower)
    {
      throw new NotImplementedException();
    }

    public IFunction<T> GetDerivateFunction<T>(int[] unsimmetricDerivate)
    {
      throw new NotImplementedException();
    }

    public IFunction<T> GetFunction<T>()
    {
      AssertType<T>();
      return (IFunction<T>) new MockFunction<TType>(mySystemSpace.Dimension, myFunc);
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

    public string PresentableName
    {
      get { return "Mock"; }
    }

    private static void AssertType<T>()
    {
      Assert.AreEqual(typeof (TType), typeof (T));
    }
  }
}