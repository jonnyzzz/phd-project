using NUnit.Framework;

namespace DSIS.CodeCompiler
{
  [TestFixture]
  public class GeneratorTypeUtilTest
  {
    [Test]
    public void Test_01()
    {
      string s = GeneratorTypeUtil.GenerateFQTypeName<GeneratorTypeUtilTest>();
      Assert.AreEqual("DSIS.CodeCompiler.GeneratorTypeUtilTest", s);
    }
    
    [Test]
    public void Test_02_1()
    {
      string s = GeneratorTypeUtil.GenerateFQTypeName<GeneratorTypeUtilTest_02<int>>();
      Assert.AreEqual("DSIS.CodeCompiler.GeneratorTypeUtilTest_02<System.Int32> ", s);
    }
    
    [Test]
    public void Test_02_2()
    {
      string s = GeneratorTypeUtil.GenerateFQTypeName<GeneratorTypeUtilTest_02<GeneratorTypeUtilTest>>();
      Assert.AreEqual("DSIS.CodeCompiler.GeneratorTypeUtilTest_02<DSIS.CodeCompiler.GeneratorTypeUtilTest> ", s);
    }    

    [Test]
    public void Test_03_1()
    {
      string s = GeneratorTypeUtil.GenerateFQTypeName<GeneratorTypeUtilTest_03<int, long>>();
      Assert.AreEqual("DSIS.CodeCompiler.GeneratorTypeUtilTest_03<System.Int32, System.Int64> ", s);
    }
    
    [Test]
    public void Test_03_2()
    {
      string s = GeneratorTypeUtil.GenerateFQTypeName<GeneratorTypeUtilTest_03<double, GeneratorTypeUtilTest>>();
      Assert.AreEqual("DSIS.CodeCompiler.GeneratorTypeUtilTest_03<System.Double, DSIS.CodeCompiler.GeneratorTypeUtilTest> ", s);
    }    
  }


  public class GeneratorTypeUtilTest_02<T>
  {    
  }

  public class GeneratorTypeUtilTest_03<T1, T2>
  {    
  }
}