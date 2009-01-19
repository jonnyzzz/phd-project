using NUnit.Framework;

namespace DSIS.Graph.Morse.Tests
{
  [TestFixture]
  public class  MorseTest : MorseBaseTest
  {
    [Test]
    public void Test_001()
    {
      DoTest(1, delegate(CostContext ctx) { ctx.DefaultCost = 1; ctx.AddEdge(1,1); });
    }
    
    [Test]
    public void Test_002()
    {
      DoTest(1, delegate(CostContext ctx) { ctx.DefaultCost = 1; ctx.AddEdge(1,2);ctx.AddEdge(2,1); });
    }
    
    [Test]
    public void Test_003()
    {
      DoTest(1, delegate(CostContext ctx) { ctx.DefaultCost = 1; ctx.AddEdge(1, 2); ctx.AddEdge(2, 3); ctx.AddEdge(3, 1); });
    }
    
    [Test]
    public void Test_004()
    {
      for (int n = 4; n < 50; n++)
        DoTest(1, delegate(CostContext ctx)
                    {
                      ctx.DefaultCost = 1;
                      int i = 0;
                      for (; i < n; i++ )
                        ctx.AddEdge(i, i+1);
                      ctx.AddEdge(n, 0);
                    });
    }

    [Test]
    public void Test_006()
    {
       DoTest(1.666666666666666, delegate(CostContext ctx)
                    {
                      ctx.DefaultCost = 1;
                      
                      ctx.AddEdge(1, 3);
                      ctx.AddEdge(1, 2);
                      ctx.AddEdge(2, 3);

                      ctx.AddEdge(3, 1);
                      
                      ctx.AddCost(2, 3);
                    });
    }
    
    [Test]
    public void Test_007()
    {
       DoTest(1, delegate(CostContext ctx)
                    {
                      ctx.DefaultCost = 1;
                      
                      ctx.AddEdge(1, 3);
                      ctx.AddEdge(1, 2);
                      ctx.AddEdge(2, 3);

                      ctx.AddEdge(3, 1);
                      
                      ctx.AddCost(2, 0.1);
                    });
    }
  }
}