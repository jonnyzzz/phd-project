using System.Reflection;
using DSIS.CodeCompiler;
using DSIS.IntegerCoordinates.Generic;
using DSIS.Utils.Test;
using NUnit.Core;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Generated
{

  [TestFixture]
  public class GeneratedIntegerCoordinateSystemManagerTest
  {
    private GeneratedIntegerCoordinateSystemManager myManager;

    [SetUp]
    public void SetUp()
    {
      myManager = new GeneratedIntegerCoordinateSystemManager();
    }

    [Test]
    public void Test_CanCompile()
    {
      for (int i = 1; i < 10; i++)
        myManager.CreateSystem(i);
    }

    [Test]
    public void Test_Dimension1()
    {
      IIntegerCoordinateFactory system = myManager.CreateSystem(1);

      ICodeCompiler compiler = CodeCompiler.CodeCompiler.CreateCompiler();
      Assembly ass = compiler.CompileCSharpCode(string.Format(
                                                  @" 
           using NUnit.Framework;
           using DSIS.IntegerCoordinates.Generated; 
           using DSIS.IntegerCoordinates.Generic; 
           
          [TestFixture]
          public class Test1 : CellConnectionAdapterOneDimBaseTest<{0},{1}> {{
              private readonly GeneratedIntegerCoordinateSystemManager myManager = 
                                    new GeneratedIntegerCoordinateSystemManager();

             protected override {0} CoordinateSystem()
             {{
                return new {0}(mySpace  );
             }}
          }}
",
                                                  GeneratorTypeUtil.GenerateFQTypeName(system.System),
                                                  GeneratorTypeUtil.GenerateFQTypeName(system.Coordinate)),
                                                typeof (TestFixture),
                                                GetType(),
                                                typeof (GeneratedIntegerCoordinateSystemManager),
                                                system.GetType(),
                                                system.System,
                                                system.Coordinate,
                                                typeof (CellConnectionAdapterOneDimBaseTest<,>),
                                                typeof(IntegerCoordinateSystemBaseTest<,>)
                                                );
      NUnitFixtureHelper.RunTests(ass);
    }

    [Test]
    public void Test_Dimension2()
    {
      IIntegerCoordinateFactory system = myManager.CreateSystem(2);

      ICodeCompiler compiler = CodeCompiler.CodeCompiler.CreateCompiler();
      Assembly ass = compiler.CompileCSharpCode(string.Format(
                                                  @" 
           using NUnit.Framework;
           using DSIS.IntegerCoordinates.Generated; 
           using DSIS.IntegerCoordinates.Generic; 
           
          [TestFixture]
          public class Test1 : CellConnectionAdapterTwoDimBaseTest<{0},{1}> {{
              private readonly GeneratedIntegerCoordinateSystemManager myManager = 
                                    new GeneratedIntegerCoordinateSystemManager();

             protected override {0} CoordinateSystem()
             {{
                return new {0}(mySpace  );
             }}
          }}

          [TestFixture]
          public class Test2 : IntegerCoordinateSystemBaseTest<{0},{1}> {{
              private readonly GeneratedIntegerCoordinateSystemManager myManager = 
                                    new GeneratedIntegerCoordinateSystemManager();

             protected override {0} CoordinateSystem()
             {{
                return new {0}(mySpace  );
             }}
          }}
",
                                                  GeneratorTypeUtil.GenerateFQTypeName(system.System),
                                                  GeneratorTypeUtil.GenerateFQTypeName(system.Coordinate)),

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