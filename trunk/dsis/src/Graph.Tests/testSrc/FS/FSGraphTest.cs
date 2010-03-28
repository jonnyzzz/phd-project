using NUnit.Framework;

namespace DSIS.Graph.Tests.FS
{
  [TestFixture]
  public class FSGraphTest : FSGraphTestBase
  {
    [Test]
    public void TestOneNodeGraph()
    {
      TestGraphEdgesBuilt(e(p(1,1)));
    }

    [Test]
    public void TestTwoNodesGraph()
    {
      TestGraphEdgesBuilt(e(p(1,1,2), p(2,2,1)));
    }    
  }
}