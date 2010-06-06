using DSIS.Scheme.Exec;
using NUnit.Framework;

namespace DSIS.Scheme.Tests
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
      var g = new ActionGraph();
      g.AddEdge(Create("a"), Create("b"));
      g.Execute();

      AssertData("|a||b|");
    }

    [Test]
    public void Test_AddSameAction()
    {
      var g = new ActionGraph();
      var a = Create("a");
      g.AddEdge(a, Create("b"));
      g.AddEdge(a, Create("c"));
      g.AddEdge(a, Create("d"));
      g.Execute();

      AssertData("|a||b||c||d|");      
    }


    [Test]
    public void Test_03_4nodes()
    {
      var g = new ActionGraph();
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
      var g = new ActionGraph();
      IAction a = Create("a");
      g.AddEdge(a,a);

      g.Execute();

      AssertData("");
    }

    [Test]
    [ExpectedException(typeof(ActionGraphException))]
    public void Test_05_Loop()
    {
      var g = new ActionGraph();
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
      var g = new ActionGraph();
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
      var g = new ActionGraph();
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

    [Test]
    public void Test_08_ContextClash()
    {
      var o1 = new Obj();
      var o2 = new Obj();
      IAction a1 = Create<Obj>("A", o1);
      IAction a2 = Create<Obj>("A", o2);
      IAction sink = Create("A");

      var g = new ActionGraph();
      g.AddEdge(a1, sink);
      g.AddEdge(a2, sink);

      try
      {
        g.Execute();
        Assert.Fail("Exception expected");
      } catch
      {
        //NOP
        //Drop        
      }

      Assert.That(o1.EqualsCalled || o2.EqualsCalled, Is.True);
    }

    [Test]
    public void Test_09_ContextClashRecoverable()
    {
      Obj obj = new Obj();
      IAction a1 = Create<Obj>("A", obj);
      IAction a2 = Create<Obj>("A", obj);
      IAction sink = Create("B");

      var g = new ActionGraph();
      g.AddEdge(a1, sink);
      g.AddEdge(a2, sink);

      g.Execute();    
  
      AssertData("|A||A||B|");
    }

    private class Obj
    {
      public bool EqualsCalled; 
      public override bool Equals(object obj)
      {
        EqualsCalled = true;
        return ReferenceEquals(this, obj);
      }

      public override int GetHashCode()
      {
        return 0  ;
      }
    }
  }
}