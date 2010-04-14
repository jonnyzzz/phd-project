using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Persistance.Tests
{
  [TestFixture]
  public class GeneratedIntegerCoordinateSystemPersistanceTest : PersistanceTestBase
  {
    private IPersistance<IIntegerCoordinateSystem> myManager;
    private GeneratedIntegerCoordinateSystemManager myFactory;

    [SetUp]
    public void SetUp()
    {
      var codeCompiler = CodeCompiler.CodeCompiler.CreateCompiler();

      myManager =
        new IntegerCoordinatePersistance(
          new DefaultSystemSpacePersistance(),
          new GeneratedIntegerCoordinateFactory(myFactory = new GeneratedIntegerCoordinateSystemManager(codeCompiler)))
      ;
    }

    [TearDown]
    public void TearDown()
    {
      myManager = null;
    }

    [Test]
    public void Test_01()
    {
      DoTest(new DefaultSystemSpace(1, 1.0.Fill(1), 2.0.Fill(1), 5L.Fill(1)));
    }

    [Test]
    public void Test_02()
    {
      DoTest(new DefaultSystemSpace(2, new[] { 1.0, 1.1 }, new[] { 2.0, 2.1 }, new[] { 5L, 6L }));
    }

    [Test]
    public void Test_03()
    {
      DoTest(new DefaultSystemSpace(3, new[] { 1.0, 1.1, 1.2 }, new[] { 2.0, 2.1, 2.2 }, new[] { 5L, 6L, 7L }));
    }

    private void DoTest(ISystemSpace space)
    {
      var o = myFactory.CreateSystem(space.Dimension, "int").Create(space, space.InitialSubdivision);
      DoTest(o, (w, x) => myManager.Save(x, w),
             r => myManager.Load(r),
             Assert.AreEqual);

      o = myFactory.CreateSystem(space.Dimension, "short").Create(space, space.InitialSubdivision);
      DoTest(o, (w, x) => myManager.Save(x, w),
             r => myManager.Load(r),
             Assert.AreEqual);

      o = myFactory.CreateSystem(space.Dimension, "long").Create(space, space.InitialSubdivision);
      DoTest(o, (w, x) => myManager.Save(x, w),
             r => myManager.Load(r),
             Assert.AreEqual);
    }
  }
}