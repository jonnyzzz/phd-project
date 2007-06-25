using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DSIS.CodeCompiler;
using DSIS.IntegerCoordinates.Generic;
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

    [Test][Ignore("Have to fix compilation of the test")]
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

/*             protected override {0} CoordinateSystem()
             {{
                return new {0}(mySystem);
             }} */
          }}
         ",
                                   GeneratorTypeUtil.GenerateFQTypeName(system.System),
                                   GeneratorTypeUtil.GenerateFQTypeName(system.Coordinate)),
                                   typeof(TestFixture), 
                                   GetType(), 
                                   typeof(GeneratedIntegerCoordinateSystemManager), 
                                   system.GetType(), 
                                   typeof(CellConnectionAdapterOneDimBaseTest<,>));
        
      SimpleTestRunner runner = new SimpleTestRunner();
      ArrayList asss = new ArrayList();
      asss.Add(ass.Location);
      TestPackage package = new TestPackage("Package",asss);
      runner.Load(package);

      Assert.IsTrue(runner.Run(NullListener.NULL).IsSuccess);     
    }
  }
}
