using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;
using NUnit.Framework;

namespace DSIS.Scheme.testSrc
{
  [TestFixture]
  public class ActionsTest : ActionTestBase
  {
    [Test]
    public void Test_Agregate()
    {
      var g = new ActionGraph();

      var a = new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
            bld.AddEdge(bld.Start, Create("in_a"));
            var in_c = Create("in_c");
            bld.AddEdge(Create("in_b"), in_c);
            bld.AddEdge(in_c, bld.End);      
          });
      
      g.AddEdge(Create("a"), a);
      g.AddEdge(a, Create("b"));

      g.Execute();

      AssertData("|a||in_a||in_b||in_c||b|");
    }

    [Test]
    public void Test_Loop()
    {
      var g = new ActionGraph();

      var la = new LoopAction("a", 4, Create("a"));
      g.AddEdge(Create("z"), la);
      g.AddEdge(la, Create("x"));

      g.Execute();

      AssertData("|z||a||a||a||a||x|");
    }
  }
}