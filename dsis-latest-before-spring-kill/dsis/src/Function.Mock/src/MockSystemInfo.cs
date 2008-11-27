using System;
using DSIS.Core.System;
using DSIS.Core.System.Tree;
using NUnit.Framework;

namespace DSIS.Function.Mock
{
  public class MockSystemInfo<TType> : ISystemInfo, ISystemInfoAndSpaceProvider
  {
    private readonly ComputeFunction<TType> myFunc;
    private readonly ISystemSpace mySystemSpace;

    public MockSystemInfo(ComputeFunction<TType> func, ISystemSpace systemSpace)
    {
      myFunc = func;
      mySystemSpace = systemSpace;
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int derivatePower)
    {
      throw new NotImplementedException();
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int[] unsimmetricDerivate)
    {
      throw new NotImplementedException();
    }

    public IFunction<T> GetFunction<T>(T[] precision)
    {
      AssertType<T>();
      return (IFunction<T>) new MockFunction<TType>(Dimension, myFunc);
    }

    public IFunction<T> GetFunction<T>(T precision)
    {
      T[] ts = new T[Dimension];
      for(int i=0; i< Dimension; i++)
      {
        ts[i] = precision;
      }
      return GetFunction<T>(ts);
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

    public int Dimension
    {
      get { return mySystemSpace.Dimension; }
    }

    private static void AssertType<T>()
    {
      Assert.AreEqual(typeof (TType), typeof (T));
    }
  }
}