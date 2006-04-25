using System;
using EugenePetrenko.Gui2.Kernell2.Document;

namespace EugenePetrenko.Gui2.Test.Function
{
  /// <summary>
  /// Summary description for TestFixture1.
  /// </summary>
  [TestFixture]
  public class MinMaxLipsitzTest
  {
    private IEvaluateFunction CreateFunction()
    {
      Kernell2.Document.Function function = Util.Util.CreateFunction(
        new double[] {0, 0, 0, 0},
        new double[] {1, 1, 10, 1},
        new int[] {1, 10, 1, 2},
        new string[] {"0", "x1", "x1*x3", "cos(x4)"});

      return function.EvaluateFunction;
    }

    /// <summary>
    /// A simple test.
    /// </summary>
    [Test]
    public void TestDimension0()
    {
      IEvaluateFunction evaluateFunction = CreateFunction();

      Assert.Equals(evaluateFunction.MinimalValue[0], 0);
      Assert.Equals(evaluateFunction.MaximalValue[0], 0);
      Assert.Equals(evaluateFunction.LipshitzConstant[0], 0);
    }

    [Test]
    public void TestDimension1()
    {
      IEvaluateFunction evaluateFunction = CreateFunction();

      Assert.Equals(evaluateFunction.MinimalValue[1], 0);
      Assert.Equals(evaluateFunction.MaximalValue[1], 1);
      Assert.Equals(evaluateFunction.LipshitzConstant[1], 1);
    }

    [Test]
    public void TestDimension2()
    {
      IEvaluateFunction evaluateFunction = CreateFunction();

      Assert.Equals(evaluateFunction.MinimalValue[2], 0);
      Assert.Equals(evaluateFunction.MaximalValue[2], 10);
      Assert.Equals(evaluateFunction.LipshitzConstant[1], 1);
    }

    [Test]
    public void TestDimension3()
    {
      IEvaluateFunction evaluateFunction = CreateFunction();

      Util.Util.AssertDoubleEquals(evaluateFunction.MinimalValue[3], Math.Cos(1));
      Util.Util.AssertDoubleEquals(evaluateFunction.MaximalValue[3], 1);
      Util.Util.AssertDoubleEquals(evaluateFunction.LipshitzConstant[3], Math.Sin(1));
    }
  }
}