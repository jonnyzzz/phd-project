using DSIS.CellImageBuilder.Descartes;
using DSIS.Core.Ioc;
using DSIS.Core.System.Impl;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.CellImageBuilder.Tests.Descartes
{
  [TestFixture]
  public class DescartesTest : ComponentContainingTestBase
  {
    [Autowire]
    public DescartesCellImageBuilderFactory Factory { get; set; }

    [Autowire]
    public GeneratedIntegerCoordinateFactory Ics { get; set; }

    [Autowire]
    public ISystemSpaceFactory SystemSpaceFactory { get; set; }

    [Test]
    public void TestAutowiring()
    {
      Assert.That(Factory, Is.Not.Null);
      Assert.That(Ics, Is.Not.Null);
      Assert.That(SystemSpaceFactory, Is.Not.Null);
    }   

    [Test]
    public void TestGenerate()
    {
      var sp = SystemSpaceFactory.CreateSymmetricalSpace(2, 4, 2);

      var ics = Ics.Create(sp, new[] {5L, 5});

      ics.DoGeneric(new DoTestGenerate(Factory));
    }

    private class DoTestGenerate : IIntegerCoordinateSystemWith
    {
      private readonly DescartesCellImageBuilderFactory myFactory;

      public DoTestGenerate(DescartesCellImageBuilderFactory factory)
      {
        myFactory = factory;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        myFactory.GenerateImageBuilder<T,Q>(system, new[] {1, 1});
      }
    }
  }
}