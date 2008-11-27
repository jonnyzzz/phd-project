using System.Collections.Generic;
using DSIS.Core.System.Impl;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Scheme.Impl.Actions.Entropy;
using NUnit.Framework;
using DSIS.Utils;

namespace DSIS.Persistance.Tests
{
  [TestFixture]
  public class MeasureInfoPersistanceTest : PersistanceTestBase
  {
    private IPersistance<IMeasureInfo> myPersistance;
    [SetUp]
    public void SetUp()
    {
      var ps =
        new IntegerCoordinatePersistanceProxy(
          new IntegerCoordinatePersistance(
            new DefaultSystemSpacePersistance(),
            new GeneratedIntegerCoordinateSystemManager(
              CodeCompiler.CodeCompiler.CreateCompiler())
            ));

      myPersistance = new MeasureInfoPersistance(new GraphMeasurePersistance(ps));
    }

    [Test]
    public void Test_01()
    {
      var dim = 1;
      var info = new MeasureInfo<IntegerCoordinate>(0, 1, GraphMeasurePersistanceTest.CreateGraphMeasure(dim));

      DoTest(info);
    }

    [Test]
    public void Test_02()
    {
      var dim = 2;
      var info = new MeasureInfo<IntegerCoordinate>(0, 1, GraphMeasurePersistanceTest.CreateGraphMeasure(dim));

      DoTest(info);
    }

    [Test]
    public void Test_03()
    {
      var dim = 3;
      var info = new MeasureInfo<IntegerCoordinate>(0, 1, GraphMeasurePersistanceTest.CreateGraphMeasure(dim));

      DoTest(info);
    }

    private void DoTest(IMeasureInfo info)
    {
      DoTest(info, (w, m) => myPersistance.Save(m, w),
             r => myPersistance.Load(r), (a, b) =>
                                           {
                                             Assert.AreEqual(a.Step, b.Step);
                                             Assert.AreEqual(a.Proj, b.Proj);
                                             Assert.AreEqual(a.Measures().Count(), b.Measures().Count());

                                             var lA = new List<IGraphMeasure>(a.Measures());
                                             var lB = new List<IGraphMeasure>(b.Measures());

                                             Assert.AreEqual(lA.Count, lB.Count);

                                             for (var i = 0; i < lA.Count; i++)
                                             {
                                               GraphMeasurePersistanceTest.AssertM(lA[i], lB[i]);
                                             }
                                           });
    }
  }
}