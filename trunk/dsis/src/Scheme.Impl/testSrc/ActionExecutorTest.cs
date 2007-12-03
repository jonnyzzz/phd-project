using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Exec;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Scheme.Impl
{
  [TestFixture]
  public class ActionExecutorTest
  {
    private string myData;

    [SetUp]
    public void SetUp()
    {
      Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
      Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
      myData = "";      
    }

    [Test]
    public void Test_01_empty()
    {
      new ActionGraph().Execite();      
    }
    
    [Test]
    public void Test_02()
    {
      ActionGraph g = new ActionGraph();
      g.AddEdge(Create("a"), Create("b"));
      g.Execite();

      Assert.AreEqual("|a||b|", myData);
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

      g.Execite();

      Assert.AreEqual("|a||b||c||d|", myData);
    }

    private IAction Create(string name)
    {
      return new Mock(name, this);
    }

    private class Mock : IAction
    {
      private readonly string myName;
      private readonly ActionExecutorTest myInstance;

      public Mock(string name, ActionExecutorTest instance)
      {
        myName = name;
        myInstance = instance;
      }


      public override string ToString()
      {
        return myName;
      }

      public ICollection<ContextMissmatch> Compatible(Context ctx)
      {
        return EmptyArray<ContextMissmatch>.Instance;
      }

      public Context Apply(Context ctx)
      {
        myInstance.myData += "|" + myName + "|";
        Context context = new Context();
        context.Set(new Key<string>(myName), myName);
        return context;
      }
    }
  }
}
