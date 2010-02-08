using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.CodeCompiler;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Tests.Generic;
using DSIS.Utils;
using DSIS.Utils.Test;
using NUnit.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.IntegerCoordinates.Tests.Generated
{
  [TestFixture]
  public class GeneratedIntegerCoordinateSystemManagerTest
  {
    private GeneratedIntegerCoordinateSystemManager myManager;

    [SetUp]
    public void SetUp()
    {
      myManager = new GeneratedIntegerCoordinateSystemManager(new CodeCompilerImpl(new CodeCompilerFilenameGenerator()));
    }

    [Test]
    public void Test_CanCompile()
    {
      for (int i = 1; i < 10; i++)
      {
        var v = myManager.CreateSystem(i, "short");
        Console.Out.WriteLine("v.GetType() = {0}", v.GetType());        

        v = myManager.CreateSystem(i, "int");
        Console.Out.WriteLine("v.GetType() = {0}", v.GetType());        

        v = myManager.CreateSystem(i, "long");
        Console.Out.WriteLine("v.GetType() = {0}", v.GetType());        
      }
    }

    [Test]
    public void Test_Identity_long()
    {
      for(int i = 1; i<10; i++)
      {
        IIntegerCoordinateFactoryEx system = myManager.CreateSystem(i, "long");
        IIntegerCoordinateSystem info = system.Create(new MockSystemSpace(i, Fill(0.0, i), Fill(1.0, i), Fill(1000L,i)), Fill(10000000L, i));

        Assert.That(info.IsGenerated, Is.True);
        info.DoGeneric(new DoWithCoordunates_Identity());
      }
    }

    [Test]
    public void Test_Identity_int()
    {
      for(int i = 1; i<10; i++)
      {
        IIntegerCoordinateFactoryEx system = myManager.CreateSystem(i, "int");
        IIntegerCoordinateSystem info = system.Create(new MockSystemSpace(i, Fill(0.0, i), Fill(1.0, i), Fill(1000L,i)), Fill(100000L, i));

        Assert.That(info.IsGenerated, Is.True);
        info.DoGeneric(new DoWithCoordunates_Identity());
      }
    }

    [Test]
    public void Test_Identity_short()
    {
      for(int i = 1; i<10; i++)
      {
        IIntegerCoordinateFactoryEx system = myManager.CreateSystem(i, "short");
        IIntegerCoordinateSystem info = system.Create(new MockSystemSpace(i, Fill(0.0, i), Fill(1.0, i), Fill(1000L,i)), Fill(1000L, i));

        Assert.That(info.IsGenerated, Is.True);
        info.DoGeneric(new DoWithCoordunates_Identity());
      }
    }

    private class DoWithCoordunates_Identity : IIntegerCoordinateSystemWith
    {
      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        for (int i = 0; i < system.Dimension; i++)
        {
          for (double v = 0; v < 1; v += 0.00001)
          {
            Assert.AreEqual(v, system.ToExternal(system.ToInternal(v, i), i), system.CellSize[i]);
          }
        }
      }
    }

    [Test]
    public void Test_Subdivision_short()
    {
      for (int i = 1; i < 10; i++)
      {
        IIntegerCoordinateFactoryEx system = myManager.CreateSystem(i, "short");
        IIntegerCoordinateSystem info = system.Create(new MockSystemSpace(i, Fill(0.0, i), Fill(1.0, i), Fill(1000L, i)), Fill(1000L, i));

        info.DoGeneric(new DoWithCoordunates_Subdivision());
      }
    }

    [Test]
    public void Test_Subdivision_int()
    {
      for (int i = 1; i < 10; i++)
      {
        IIntegerCoordinateFactoryEx system = myManager.CreateSystem(i, "int");
        IIntegerCoordinateSystem info = system.Create(new MockSystemSpace(i, Fill(0.0, i), Fill(1.0, i), Fill(1000L, i)), Fill(100000L, i));

        info.DoGeneric(new DoWithCoordunates_Subdivision());
      }
    }

    [Test]
    public void Test_Subdivision_long()
    {
      for (int i = 1; i < 10; i++)
      {
        IIntegerCoordinateFactoryEx system = myManager.CreateSystem(i, "long");
        IIntegerCoordinateSystem info = system.Create(new MockSystemSpace(i, Fill(0.0, i), Fill(1.0, i), Fill(1000L, i)), Fill(100000L, i));

        info.DoGeneric(new DoWithCoordunates_Subdivision());
      }
    }


    private class DoWithCoordunates_Subdivision : IIntegerCoordinateSystemWith
    {
      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        var div = system.Subdivide(2L.Fill(system.Dimension));
        Assert.IsTrue(!div.GetType().IsGenericType);

        var x = system.Create(100L.Fill(system.Dimension));
        var set = new HashSet<Q>(EqualityComparerFactory<Q>.GetComparer());
        set.UnionWith(div.Subdivide(x));

        Assert.IsTrue(set.Contains(((T)div.ToSystem).Create(200L.Fill(system.Dimension))));
        Assert.IsTrue(set.Contains(((T)div.ToSystem).Create(201L.Fill(system.Dimension))));
      }
    }

    private static T[] Fill<T>(T v, int length)
    {
      T[] arr = new T[length];
      for(int i=0; i<length;i++)
      {
        arr[i] = v;
      }
      return arr;
    }


    [Test] public void Test_Dimension1_long() { Do_Dimension1("long");}
    [Test] public void Test_Dimension1_int() { Do_Dimension1("int");}
    [Test] public void Test_Dimension1_short() { Do_Dimension1("short");}

      
    private void Do_Dimension1(string type)
    {
      IIntegerCoordinateFactoryEx system = myManager.CreateSystem(1, type);

      ICodeCompiler compiler = CodeCompiler.CodeCompiler.CreateCompiler();
      Assembly ass = compiler.CompileCSharpCode(string.Format(
                                                  @" 
           using NUnit.Framework;
           using DSIS.IntegerCoordinates.Generated; 
           
          [TestFixture]
          public class Test1 : {1} {{
             protected override {0} CoordinateSystem()
             {{
                return new {0}(mySpace  );
             }}
          }}
",
 GeneratorTypeUtil.GenerateFQTypeName(system.System),
 GeneratorTypeUtil.GenerateFQTypeInstance(typeof(CellConnectionAdapterOneDimBaseTest<,>), system.System, system.Coordinate)),
                                                typeof (TestFixture),
                                                GetType(),
                                                typeof (GeneratedIntegerCoordinateSystemManager),
                                                system.GetType(),
                                                system.System,
                                                system.Coordinate,
                                                GetType(),
                                                typeof (CellConnectionAdapterOneDimBaseTest<,>),
                                                typeof(IntegerCoordinateSystemBaseTest<,>)
        );
      NUnitFixtureHelper.RunTests(ass);
    }

    [Test] public void Test_Dimension2_long() { Do_Dimension2("long");}
    [Test] public void Test_Dimension2_int() { Do_Dimension2("int");}
    [Test] public void Test_Dimension2_short() { Do_Dimension2("short");}

    private void Do_Dimension2(string type)
    {
      IIntegerCoordinateFactoryEx system = myManager.CreateSystem(2, type);

      ICodeCompiler compiler = CodeCompiler.CodeCompiler.CreateCompiler();
      Assembly ass = compiler.CompileCSharpCode(string.Format(
                                                  @" 
           using NUnit.Framework;
           using DSIS.IntegerCoordinates.Generated; 
           using DSIS.IntegerCoordinates.Tests.Generated; 
           
          [TestFixture]
          public class Test1 : {2} {{
             protected override {0} CoordinateSystem()
             {{
                return new {0}(mySpace  );
             }}
          }}

          [TestFixture]
          public class Test2 : {3} {{
             protected override {0} CoordinateSystem()
             {{
                return new {0}(mySpace  );
             }}
          }}
",
                                                  GeneratorTypeUtil.GenerateFQTypeName(system.System),
                                                  GeneratorTypeUtil.GenerateFQTypeName(system.Coordinate),
                                                  GeneratorTypeUtil.GenerateFQTypeInstance(typeof(CellConnectionAdapterTwoDimBaseTest<,>),system.System, system.Coordinate),
                                                  GeneratorTypeUtil.GenerateFQTypeInstance(typeof(IntegerCoordinateSystemBaseTest<,>),system.System, system.Coordinate)),
                                                typeof (TestFixture),
                                                GetType(),
                                                typeof (GeneratedIntegerCoordinateSystemManager),
                                                system.GetType(),
                                                system.System,
                                                system.Coordinate,
                                                typeof(CellConnectionAdapterTwoDimBaseTest<,>),
                                                typeof(IntegerCoordinateSystemBaseTest<,>)
        );

      NUnitFixtureHelper.RunTests(ass);
    }
  }
}