using System;
using DSIS.Core.System;
using DSIS.Core.System.Tree;

namespace DSIS.Function.Predefined.Henon
{
  public class HenonFunctionSystemInfoDecorator : SystemInfoDecoratorBase, ISystemInfo
  {
    private readonly double myA;

    public HenonFunctionSystemInfoDecorator(ISystemSpace systemSpace, double a) : base(systemSpace)
    {
      myA = a;
    }

    public IFunction<T> GetFunction<T>(int iteration)
    {
      if (iteration != 1)
        throw new ArgumentException("iteration = 1 is only supported", "iteration");
      if (typeof(T) != typeof(double))
        throw new ArgumentException("T should by double");

      return  (IFunction<T>) new HenonFunction(myA);
    }

    public IFunction<T> GetDerivateFunction<T>(int iteration, int derivatePower)
    {
      if (iteration != 1)
        throw new ArgumentException("iteration = 1 is only supported", "iteration");
      if (derivatePower <= 1)
        throw new UnsupportedDevivateException("derivatePower <= 1 is only supported");
      if (typeof (T) != typeof (double))
        throw new ArgumentException("T should by double");

      if (derivatePower == 0)
        return GetFunction<T>(1);
      return (IFunction<T>) new HenonFunctionDerivate(myA);
    }

    public IFunction<T> GetDerivateFunction<T>(int iteration, int[] unsimmetricDerivate)
    {
      throw new UnsupportedDevivateException("This operation is not supported");
    }

    public Q ProcessFunctionTree<Q>(IFunctionTreeVisitor<Q> visitor)
    {
      throw new NotImplementedException();
    }

    public Type[] SupportedFunctionTypes
    {
      get { return new Type[] {typeof (double)}; }
    }
  }
}