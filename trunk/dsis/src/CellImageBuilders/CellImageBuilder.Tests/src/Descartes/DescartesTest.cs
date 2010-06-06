using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.Descartes;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using EugenePetrenko.Shared.Core.Ioc.Api;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using DSIS.Utils;

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
      Assert.That(Factory, SyntaxHelper.Not.Null);
      Assert.That(Ics, SyntaxHelper.Not.Null);
      Assert.That(SystemSpaceFactory, SyntaxHelper.Not.Null);
    }

    [Test]
    public void TestGenerate()
    {
      var sp = SystemSpaceFactory.CreateSymmetricalSpace(2, 4, 2);

      var ics = Ics.Create(sp, new[] {5L, 5});

      ics.DoGeneric(new DoTestGenerate(Factory));
    }

    [Test]
    public void TestDescartes_Empty()
    {
      var sp = SystemSpaceFactory.CreateSameSpace(2, 0, 4, 2000);
      var ics = Ics.Create(sp, new[] {2000L, 2000L});

      ics.DoGeneric(new DoTestBuilderBase(Factory)
                      {
                        Functions = new Func<double, double>[] { x => -1000.0, x => { throw new NotImplementedException(); } },
                        Result = new string[0]
                      });
    }

    [Test]
    public void TestDescartes_SimplePoint()
    {
      var sp = SystemSpaceFactory.CreateSameSpace(2, 0, 4, 2000);
      var ics = Ics.Create(sp, new[] {2000L, 2000L});

      ics.DoGeneric(new DoTestBuilderBase(Factory)
                      {
                        Functions = new Func<double, double>[] { x => 1.0, x => 1.0 },
                        Result = new[] {"499, 499", "499, 500", "500, 499", "500, 500"}
                      });
    }

    private class DoTestBuilderBase : DoTestGenerate
    {
      public Func<double, double>[] Functions { get; set;}
      public int BuildImages { get; private set; }
      public string[] Result { get; set; }

      public DoTestBuilderBase(DescartesCellImageBuilderFactory factory) : base(factory)
      {
      }

      protected override void Do2<T, Q>(T system, ICellImageBuilder<Q> bld)
      {
        var pt = system.Create(100, 100);
        var builder = new ListCellConnectionBuilder<Q>();
        bld.Bind(new CellImageBuilderContext<Q>(
                   new Splittable(Functions),
                   new DescartesSettings
                   {
                     Builders = new[]
                                    {
                                      new CellImageBuilderAndRange(0,0, new BoxMethodSettings()),
                                      new CellImageBuilderAndRange(1,1, new BoxMethodSettings()),
                                    }
                   },
                   system,
                   builder)
          );

        bld.BuildImage(pt);
        BuildImages = builder.Values.Count();

        var points = new List<string>();
        foreach (var list in builder.Values.SelectMany(x=>x.Value))
        {
          points.Add(2.Each().Select(x => list.GetCoordinate(x)).JoinString(", "));
        }
        points.Sort();

        var gold = Result
          .JoinString(Environment.NewLine)
          .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
          .Select(x => x.Trim())
          .JoinString(Environment.NewLine);

        try
        {
          Assert.AreEqual(points.JoinString(Environment.NewLine), gold);
        } catch {
          foreach (var ppt in points)
          {
            Console.Out.WriteLine(ppt);
          }
          throw;
        }
      }
    }

    private class Splittable : SystemInfo, ISplittableSystemInfo
    {
      private readonly List<Func<double, double>> myFunctions = new List<Func<double, double>>();

      public Splittable(params Func<double, double>[] functions) : base(functions)
      {
        myFunctions.AddRange(functions);
      }

      public ISystemInfo ForRange(int from, int to)
      {
        var slice = new List<Func<double, double>>();
        for (int i = from; i <= to; i++)
        {
          slice.Add(myFunctions[i]);
        }
        return new SystemInfo(slice);
      }
    }

    private class SystemInfo : DoubleDescreteSystemInfoBase, ISystemInfo
    {
      private readonly IEnumerable<Func<double, double>> myFunc;

      public SystemInfo(IEnumerable<Func<double, double>> func) : base(func.Count())
      {
        myFunc = func;
      }

      public override string PresentableName
      {
        get { return "Fake/Mock " + Dimension; }
      }

      protected override IFunction<double> GetFunctionInternal()
      {
        return new Function(myFunc);
      }

      private class Function : Function<double>, IFunction<double>
      {
        private readonly IEnumerable<Func<double, double>> myFunc;

        public Function(IEnumerable<Func<double, double>> func) : base(func.Count())
        {
          myFunc = func;
        }

        public void Evaluate()
        {
          int i = 0;
          foreach (var func in myFunc)
          {
            Output[i] = func(Input[i]);
            i++;
          }
        }
      }
    }


    private class DoTestGenerate : IIntegerCoordinateSystemWith
    {
      private readonly DescartesCellImageBuilderFactory myFactory;
      protected readonly int[] mySlices = new[] {1, 1};

      public DoTestGenerate(DescartesCellImageBuilderFactory factory)
      {
        myFactory = factory;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        Do2(system, myFactory.GenerateImageBuilder<T, Q>(system, mySlices));
      }

      protected virtual void Do2<T, Q>(T system, ICellImageBuilder<Q> bld)
        where T : IIntegerCoordinateSystem<Q>
        where Q : IIntegerCoordinate
      {
      }
    }
  }
}