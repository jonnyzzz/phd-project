using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DSIS.Utils.Tests
{
  [TestFixture]
  public class BinTreePriorityQueueExRandomDataTest : BinTreePriorityQueueExTestBase
  {

    [Test]
    public void Test_01()
    {
      DoTest(@"add 1;add 2;ex;ex;add 1;add 2");      
    }

    [Test]
    public void Test_02()
    {
      DoTest(@"add 1;add 2;rmr 1; ex;");
    }

    [Test]
    public void Test_03()
    {
      DoTest(@"add 1;add 2;add 3;add 4; add 5; add 6; ex; rmr 1; ex;rmr 1; ex;rmr 1");
    }

    [Test]
    public void Test_04()
    {
      DoTest(@"add 1;add 2;add 3;add 4; add 5; add 6; ex; add -1; add -2; ex; rmr 2; ex; rmr 2; ex;rmr 2; ex;"); //
    }


    private void DoTest(string codeX)
    {
      var code =
        codeX.Split(new[] {Environment.NewLine, ";"}, StringSplitOptions.RemoveEmptyEntries)
        .Select(x => x.Trim())
        .Where(x => x.Length > 0)
        .ToArray();

      var actions = Parse(code);
      var values = new List<int>();
      var q = new Queue();

      foreach (var action in actions)
      {
        action.Apply(q, values);
      }
    }

    private static IEnumerable<Action> Parse(IEnumerable<string> commands)
    {
      var addActions = new List<AddElementAction>();
      foreach (var c in commands)
      {
        var cmd = c.ToLower().Split(' ');
        switch (cmd[0])
        {
          case "ex":
            yield return new GetNextElementAction();
            break;
          case "add":
            var action = new AddElementAction(int.Parse(cmd[1]));
            addActions.Add(action);
            yield return action;
            break;
          case "rmr":
            var index = addActions.Count - int.Parse(cmd[1]);
            var key = addActions[index];
            addActions.RemoveAt(index);
            yield return new RemoveElementAction(key);
            break;
          default:
            throw new Exception("Parse Error at: " + c);
        }
      }
    }

    private abstract class Action
    {      
      public string Name { get; private set; }
      public abstract void Apply(Queue q, List<int> values);

      protected Action(string name)
      {
        Name = name;
      }
    }

    private class RemoveElementAction : Action
    {
      private readonly AddElementAction myKey;

      public RemoveElementAction(AddElementAction key) : base("remove")
      {
        myKey = key;
      }

      public override void Apply(Queue q, List<int> values)
      {
        q.Remove(myKey.AddCookie);
        Assert.IsTrue(values.Contains(myKey.Value), "List should contains {0}", myKey.Value);
        values.Remove(myKey.Value);
      }
    }

    private class AddElementAction : Action
    {
      private readonly int myv;
      private object myAddCookie;

      public AddElementAction(int v) : base("add")
      {
        myv = v;
      }

      public override void Apply(Queue q, List<int> values)
      {
        myAddCookie = q.AddNode(myv, "Node " + myv);
        values.Add(myv);
      }

      public int Value
      {
        get { return myv; }
      }

      public object AddCookie
      {
        get { return myAddCookie; }
      }
    }

    private class GetNextElementAction : Action
    {
      public GetNextElementAction() : base("extract-min")
      {
      }

      public override void Apply(Queue q, List<int> values)
      {
        var minV = q.ExtractMin().Second;

        var expectedMin = values.Min();

        Assert.AreEqual(expectedMin, minV);
        values.Remove(minV);
      }
    }
  }
}