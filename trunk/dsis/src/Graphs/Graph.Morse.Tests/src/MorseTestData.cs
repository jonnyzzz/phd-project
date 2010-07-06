using DSIS.Utils;
using NUnit.Framework;
using Enumerable = System.Linq.Enumerable;

namespace DSIS.Graph.Morse.Tests
{
  public abstract class MorseTestData : EvaluatorTestCase
  {
    [Test]
    public void Test_OneNodeGraph()
    {
      DoTest(10, new[] { 1 }, b => b.Node(1, 10, 1));
    }

    [Test]
    public void Test_TwoNodeGraph()
    {
      DoTest(10, new[] { 1, 2 }, b =>
                                   {
                                     b.Node(1, 10, 2);
                                     b.Node(2, 10, 1);
                                   });
    }

    [Test]
    public void Test_ThreeNodeGraph()
    {
      DoTest(10, new[] { 1, 2, 3 }, b =>
                                      {
                                        b.Node(1, 10, 2);
                                        b.Node(2, 10, 3);
                                        b.Node(3, 10, 1);
                                      });
    }

    [Test]
    public void Test_003n_003e()
    {
      //     2 < - > 1 <-> 3
      DoTest(1, new[] { 1, 2 }, b =>
                                  {
                                    b.Node(1, 1, 2, 3);
                                    b.Node(2, 1, 1);
                                    b.Node(3, 9, 1);
                                  });
    }

    [Test]
    public void Test_030n_030e()
    {
      //     (2 < - > 1 ) ^ 30
      DoTest(1, new[] { 1, 2 }, b =>
                                  {
                                    var edg = Enumerable.ToArray(2.To(31));
                                    b.Node(1, 1, edg);
                                    foreach (var i in edg)
                                    {
                                      b.Node(i, i - 1, 1);
                                    }
                                  });
    }

    [Test]
    public void Test_004_006_ConcentricLoops()
    {
      //Each loop of bigger size. Answer is the shortest
      DoTest(1, new[] { 1 }, b =>
                               {
                                 b.Node(1, 1.0, 1, 2, 3);
                                 b.Node(2, 2.0, 1);
                                 b.Node(3, 4.0, 4);
                                 b.Node(4, 8.0, 1);
                               });
    }

    [Test]
    public void Test_005_008_NegativeWeight()
    {
      //Each loop of bigger size. Answer is the shortest
      DoTest(0, new[] { 1, 5 }, b =>
                                  {
                                    b.Node(1, 1.0, 1, 2, 3, 5);
                                    b.Node(2, 2.0, 1);
                                    b.Node(3, 4.0, 4);
                                    b.Node(4, 8.0, 1);
                                    b.Node(5, -1.0, 1);
                                  });
    }

    [Test]
    public void Test_005_009_NegativeWeight()
    {
      //Each loop of bigger size. Answer is the shortest
      DoTest(-1, new[] { 5 }, b =>
                                {
                                  b.Node(1, 1.0, 1, 2, 3, 5);
                                  b.Node(2, 2.0, 1);
                                  b.Node(3, 4.0, 4);
                                  b.Node(4, 8.0, 1);
                                  b.Node(5, -1.0, 1, 5);
                                });
    }

    [Test]
    public void Test_006_011_NegativeWeight()
    {
      //Each loop of bigger size. Answer is the shortest
      DoTest(-25.5, new[] { 1, 3, 4, 6 }, b =>
                                            {
                                              b.Node(1, 1.0, 1, 2, 3, 5);
                                              b.Node(2, 2.0, 1);
                                              b.Node(3, 4.0, 4);
                                              b.Node(4, 8.0, 1, 6);
                                              b.Node(5, -1.0, 1, 5);
                                              b.Node(6, -115.0, 1);
                                            });
    }

    [Test]
    public void Test_005_FullGraph() { do_Test_FullGraph(5); }
    [Test]
    public void Test_015_FullGraph() { do_Test_FullGraph(15); }
    [Test]
    public void Test_025_FullGraph() { do_Test_FullGraph(25); }
    [Test]
    public void Test_125_FullGraph() { do_Test_FullGraph(125); }
    [Test]
    public void Test_925_FullGraph() { do_Test_FullGraph(925); }

    private void do_Test_FullGraph(int nodes)
    {
      DoTest(1, null, b =>
                        {
                          for (int i = 0; i < nodes; i++)
                          {
                            b.SetWeight(i, 1);
                            for (int j = 0; j < nodes; j++)
                            {
                              b.SetEdge(i, j);
                            }
                          }
                        });
    }


    [Test]
    public void Test_006_Old()
    {
      DoTest(-1.666666666666666, new[] { 1, 2, 3 }, ctx =>
                                                      {
                                                        ctx.SetEdge(1, 3);
                                                        ctx.SetEdge(1, 2);
                                                        ctx.SetEdge(2, 3);

                                                        ctx.SetEdge(3, 1);

                                                        ctx.SetWeight(1, -1.0);
                                                        ctx.SetWeight(2, -3.0);
                                                        ctx.SetWeight(3, -1.0);
                                                      });
    }

    [Test]
    public void Test_007_Old()
    {
      DoTest(-1, new[] { 1, 3 }, ctx =>
                                   {
                                     ctx.SetEdge(1, 3);
                                     ctx.SetEdge(1, 2);
                                     ctx.SetEdge(2, 3);
                                     ctx.SetEdge(3, 1);

                                     ctx.SetWeight(1, -1.0);
                                     ctx.SetWeight(2, -0.1);
                                     ctx.SetWeight(3, -1.0);
                                   });
    }    
  }
}