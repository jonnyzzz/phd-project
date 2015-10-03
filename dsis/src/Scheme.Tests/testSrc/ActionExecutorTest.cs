using DSIS.Scheme.Exec;
using NUnit.Framework;

namespace DSIS.Scheme.testSrc
{
  [TestFixture]
  public class ActionExecutorTest : ActionTestBase
  {
    [Test]
    public void Test_01_empty()
    {
      new ActionGraph().Execute();
    }

    [Test]
    public void Test_02()
    {
      ActionGraph g = new ActionGraph();
      g.AddEdge(Create("a"), Create("b"));
      g.Execute();

      AssertData("|a||b|");
    }

    [Test]
    public void Test_03_4nodes()
    {
      ActionGraph g = new ActionGraph();
      IAction a = Create("a");
      IAction b = Create("b");
      IAction c = Create("c");
      IAction d = Create("d");

      g.AddEdge(a, b);
      g.AddEdge(a, c);
      g.AddEdge(b, d);
      g.AddEdge(c, d);

      g.Execute();

      AssertData("|a||b||c||d|");
    }

    [Test][ExpectedException(typeof(ActionGraphException))]
    public void Test_04_Loop()
    {
      ActionGraph g = new ActionGraph();
      IAction a = Create("a");
      g.AddEdge(a,a);

      g.Execute();

      AssertData("");
    }

    [Test]
    [ExpectedException(typeof(ActionGraphException))]
    public void Test_05_Loop()
    {
      ActionGraph g = new ActionGraph();
      IAction a = Create("a");
      IAction b = Create("b");
      g.AddEdge(a,b);
      g.AddEdge(b,a);

      g.Execute();

      AssertData("");
    }

    [Test]
    [ExpectedException(typeof(ActionGraphException))]
    public void Test_06_Loop()
    {
      ActionGraph g = new ActionGraph();
      IAction a = Create("a");
      IAction b = Create("b");
      g.AddEdge(a,b);
      g.AddEdge(b,b);
      g.AddEdge(b,a);
      g.AddEdge(a,a);

      g.Execute();

      AssertData("");
    }

    [Test]
    [ExpectedException(typeof(ActionGraphException))]
    public void Test_07_Loop()
    {
      ActionGraph g = new ActionGraph();
      IAction a = Create("a");
      IAction b = Create("b");
      g.AddEdge(Create("z"), a);
      g.AddEdge(a,b);
      g.AddEdge(b,b);
      g.AddEdge(b,a);
      g.AddEdge(a,a);

      g.Execute();

      AssertData("|z|");
    }
  }
}