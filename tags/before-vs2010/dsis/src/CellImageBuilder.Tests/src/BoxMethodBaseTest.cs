using DSIS.CellImageBuilder.BoxMethod;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests
{
  [TestFixture]
  public class BoxMethod_IntegerCoordinateTest : BoxMethodBaseTest
  {
    protected override IIntegerCoordinateFactory IntegerCoordinateFactory
    {
      get { return new IntegerCoordinateSystemFactoryImpl(); }
    }
  }

  [TestFixture]
  public class BoxMethod_Generated_ShortTest : BoxMethodBaseTest
  {
    private readonly GeneratedIntegerCoordinateFactory factory = new GeneratedIntegerCoordinateFactory(new GeneratedIntegerCoordinateSystemManager(CodeCompiler.CodeCompiler.CreateCompiler()));
    protected override IIntegerCoordinateFactory IntegerCoordinateFactory
    {
      get { return factory.ForType(GeneratedIntegerCoordinateFactory.ValuesType.Short); }
    }
  }

  [TestFixture]
  public class BoxMethod_Generated_IntTest : BoxMethodBaseTest
  {
    private readonly GeneratedIntegerCoordinateFactory factory = new GeneratedIntegerCoordinateFactory(new GeneratedIntegerCoordinateSystemManager(CodeCompiler.CodeCompiler.CreateCompiler()));
    protected override IIntegerCoordinateFactory IntegerCoordinateFactory
    {
      get { return factory.ForType(GeneratedIntegerCoordinateFactory.ValuesType.Int); }
    }
  }

  [TestFixture]
  public class BoxMethod_Generated_LongTest : BoxMethodBaseTest
  {
    private readonly GeneratedIntegerCoordinateFactory factory = new GeneratedIntegerCoordinateFactory(new GeneratedIntegerCoordinateSystemManager(CodeCompiler.CodeCompiler.CreateCompiler()));
    protected override IIntegerCoordinateFactory IntegerCoordinateFactory
    {
      get { return factory.ForType(GeneratedIntegerCoordinateFactory.ValuesType.Long); }
    }
  }

  public abstract class BoxMethodBaseTest : MethodTestBase
  {
    private static BoxMethodSettings GetBoxMethodDefaultSettings()
    {
      return new BoxMethodSettings { Eps = 0.1 };
    }

    [Test]
    public void Test_02()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });

      DoTestMethod(ss, new[]{5L,5L},
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = ins[0];
                     outs[1] = ins[1];
                   }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ..........
                      ....xxx...
                      ....xxx...
                      ....xxx...
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_03()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });

      DoTestMethod(ss, new[]{5L, 5L},
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 5;
                     outs[1] = 5;
                   }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ..........
                      ....xx....
                      ....xx....
                      ..........
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_04()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });

      DoTestMethod(ss, new[]{2L, 2L},
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 2 * ins[0];
                     outs[1] = 2 * ins[1];
                   }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ...xxxx...
                      ...xxxx...
                      ...xxxx...
                      ...xxxx...
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_05()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });

      DoTestMethod(ss, new[] {1L,1L},
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 0.1 * ins[0];
                     outs[1] = 7 * ins[1];
                   }, stategy,
                   @"-------------------
                      ......xxxx
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_06()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });

      DoTestMethod(ss, new[] { 1L, 1L },
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 3 + 0.1 * ins[0];
                     outs[1] = 7 * ins[1] - 2;
                   }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ....xxxxxx
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_07()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] { 0, 0 }, new double[] { 10, 10 }, new long[] { 10, 10 });

      DoTestMethod(ss, new[]{1L, 1L},
                   delegate(double[] ins, double[] outs)
                   {
                     outs[0] = 3.45 + 0.001 * ins[0];
                     outs[1] = 0.001 * ins[1] + 2.66;
                   }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ..x.......
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }
  }
}