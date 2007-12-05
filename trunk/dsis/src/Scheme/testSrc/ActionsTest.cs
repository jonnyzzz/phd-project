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
      ActionGraph g = new ActionGraph();

      AgregateAction a = new AgregateAction();
      IActionGraphPartBuilder builder = a.Builder;

      builder.AddEdge(builder.Start, Create("in_a"));
      IAction in_c = Create("in_c");
      builder.AddEdge(Create("in_b"), in_c);
      builder.AddEdge(in_c, builder.End);

      g.AddEdge(Create("a"), a);
      g.AddEdge(a, Create("b"));

      g.Execute();

      AssertData("|a||in_a||in_b||in_c||b|");
    }

    [Test]
    public void Test_Loop()
    {
      ActionGraph g = new ActionGraph();

      LoopAction la = new LoopAction(4, Create("a"));
      g.AddEdge(Create("z"), la);
      g.AddEdge(la, Create("x"));

      g.Execute();

      AssertData("|z||a||a||a||a||x|");
    }
  }
}