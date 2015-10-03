using NUnit.Framework;

namespace DSIS.Utils.testSrc
{
  [TestFixture]
  public class Log2HelperTest
  {
    [Test]
    public void Test_01()
    {
      DoTest(0, 1);
    }
    
    [Test]
    public void Test_02()
    {
      DoTest(1, 2);
    }
    
    [Test]
    public void Test_03()
    {
      DoTest(2, 3);
    }
    
    [Test]
    public void Test_04()
    {
      DoTest(3, 3);
    }
    
    [Test]
    public void Test_05()
    {
      DoTest(4, 4);
    }
    
    [Test]
    public void Test_06()
    {
      DoTest(5, 4);
    }
    
    [Test]
    public void Test_07()
    {
      DoTest(6, 4);
    }
    
    [Test]
    public void Test_08()
    {
      DoTest(7, 4);
    }
    
    [Test]
    public void Test_09()
    {
      DoTest(8, 5);
    }

    private static void DoTest(int v, int r)
    {
      Assert.AreEqual(r, Log2Helper.Nearest(v));
    }
  }
}