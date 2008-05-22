using DSIS.Spring.Attributes;
using NUnit.Framework;

namespace DSIS.Spring.Tests
{
  [SpringBean]
  public class App : IApplicationEntryPoint
  {
    public int Main(string[] args)
    {
      return 1;
    }
  } 
  [TestFixture]
  public class SpringTest
  {
    [Test]
    public void Test_01()
    { 
      Assert.AreEqual(1, SpringIoCSetup.AsMain<App>(new string[0]));
    }
  }
}