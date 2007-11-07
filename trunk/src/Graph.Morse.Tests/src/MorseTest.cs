using NUnit.Framework;

namespace DSIS.Graph.Morse.Tests
{
  [TestFixture]
  public class MorseTest : MorseBaseTest
  {
    [Test]
    public void Test_001()
    {
      DoTest(1, delegate(CostContext ctx) { ctx.DefaultCost = 1; ctx.AddEdge(1,1); });
    }
    
    [Test, Ignore("Hung")]
    public void Test_002()
    {
      DoTest(1, delegate(CostContext ctx) { ctx.DefaultCost = 1; ctx.AddEdge(1,2);ctx.AddEdge(2,1); });
    }
  }
}