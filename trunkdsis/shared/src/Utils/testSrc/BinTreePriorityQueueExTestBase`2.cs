using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace DSIS.Utils.testSrc
{
  public abstract class BinTreePriorityQueueExTestBase<T, Q, TQueue>
    where TQueue : BinTreePriorityQueueExTestBase<T, Q, TQueue>.Queue
  {
    protected TQueue queue;

    protected abstract TQueue Create();

    [SetUp]
    public void SetUp()
    {
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-us");
      queue = Create();
    }

    public class Queue : BinTreePriorityQueueEx<T, Q>
    {
      public Queue(IComparer<Q> comparer) : base(comparer)
      {
      }

      private object myAdded;

      protected override void NodeAdded(Node node)
      {
        base.NodeAdded(node);
        myAdded = node;
      }

      public new object AddNode(Q value, T data)
      {
        base.AddNode(value, data);
        return myAdded;
      }

      public void Consolidate()
      {
        DoConsolidate();
      }

      public T Min
      {
        get
        {
          DoConsolidate();
          return myMin == null ? default(T) : myMin.Data;
        }
      }

      public void Remove(object o)
      {
        base.Remove((Node) o);
      }

      public void AssertConsolidate(params string[] data)
      {
        Consolidate();
        AssertQueue(data);
      }

      public void AssertQueue(params string[] data)
      {
        AssertQueue(Dump(), data);
      }

      public void AssertConsolidateGroup(params string[] data)
      {
        Node[] nodes = Group();
        if (nodes == null)
          Assert.AreEqual("[null]", String.Join("", data));
        else
        {
          StringBuilder sb = new StringBuilder();
          foreach (Node node in nodes)
          {
            if (node == null)
            {
              sb.AppendLine("<null>");
            }
            else
            {
              node.Sibling = null;
              node.PrevSibling = null;
              DumpTree("", 0, node, sb);
            }
            sb.AppendLine("|");
          }

          AssertQueue(sb.ToString(), data);
        }
      }

      private static void AssertQueue(string act, params string[] data)
      {
        try
        {
          List<String> actual = new List<String>();
          act = Regex.Replace(act.Trim(), @" d=\d+", "");
          foreach (string trim in act.Split('\n'))
          {
            actual.Add(trim.Trim());
          }

          Assert.AreEqual(string.Join("\n", data).Trim(), string.Join("\n", actual.ToArray()).Trim());
        }
        catch (Exception e)
        {
          Console.Out.WriteLine(act);
          throw new Exception(e.Message, e);
        }
      }


      private static void DumpTree(string so, int offset, Node node, StringBuilder sb)
      {
        sb.AppendFormat("{2}{0, 3}. {1}", offset, node, so);
        sb.AppendFormat(" d={0}", node.Degree);
        sb.AppendLine();

        Node child = node.Child;
        if (child != null)
        {
          DumpTree("  " + so, offset + 1, child, sb);
          for (Node n = child.Sibling; n != child; n = n.Sibling)
            DumpTree("  " + so, offset + 1, n, sb);
        }
      }

      public void Debug()
      {
        Console.Out.WriteLine("Dump() = \n{0}", Dump());
      }

      internal string Dump()
      {
        StringBuilder sb = new StringBuilder();

        if (myMin == null)
          sb.AppendLine("<null>");
        else
        {
          DumpTree("", 0, myMin, sb);

          for (Node node = myMin.Sibling; node != myMin; node = node.Sibling)
          {
            sb.AppendLine("|");
            DumpTree("", 0, node, sb);
          }
        }

        return sb.ToString();
      }

      public enum ActionType
      {
        Add,
        Remove,
        Max,
        Dump,
        Break
      }

      public struct Action
      {
        public readonly ActionType ActionType;
        public readonly Q Q;
        public readonly T T;

        public Action(ActionType action, Q q, T t)
        {
          ActionType = action;
          Q = q;
          T = t;
        }

        public Action(ActionType actionType) : this(actionType, default(Q), default(T))
        {
        }
      }

      public void ScriptTest(string script, Converter<string, Action> parse)
      {
        Dictionary<T, object> cache = new Dictionary<T, object>();
        Dictionary<T, Q> cache2 = new Dictionary<T, Q>();
        string[] data = script.Split('\n');

        Comparison<T> comparison = delegate(T t1, T t2)
                                     {
                                       Q q1 = cache2[t1];
                                       Q q2 = cache2[t2];

                                       return myComparer.Compare(q1, q2);
                                     };

        for (int i = 0; i < data.Length; i++)
        {
          string s = data[i].Trim();
          if (s.Length == 0)
            continue;

          try
          {
            Action p = parse(s);

            switch (p.ActionType)
            {
              case ActionType.Break:
                Debugger.Break();
                break;
              case ActionType.Add:
                cache.Add(p.T, AddNode(p.Q, p.T));
                cache2.Add(p.T, p.Q);
                break;
              case ActionType.Remove:
                object node = cache[p.T];
                cache.Remove(p.T);
                cache2.Remove(p.T);
                Remove(node);
                break;
              case ActionType.Max:
                Pair<T, Q> pair = ExtractMin();
                List<T> list = new List<T>(cache.Keys);
                list.Sort(comparison);
                T exp = list[0];
                Q v = cache2[exp];
                Hashset<T> set = new Hashset<T>();
                set.Add(exp);
                for (int rrr = 1; rrr < list.Count; rrr++)
                {
                  if (cache2[list[rrr]].Equals(v))
                    set.Add(list[rrr]);
                  else
                    break;
                }
                try
                {
                  Assert.IsTrue(set.Contains(pair.First));
                  Assert.AreEqual(p.T, pair.First);
                }
                catch (Exception e)
                {
                  throw new Exception(
                    string.Format("[was]{0} <> [scr]{1} <> [exp]{2}", pair.First, p.T, set) + " " + e.Message, e);
                }
                cache.Remove(pair.First);
                cache2.Remove(pair.First);

                break;
              case ActionType.Dump:
                Debug();
                break;
            }
          }
          catch (Exception e)
          {
            throw new Exception("Failed at line " + (i + 1) + " '" + s + "' " + e.Message, e);
          }
        }

        List<T> l = new List<T>(cache.Keys);
        l.Sort(comparison);
        Queue<T> q = new Queue<T>(l);

        while (q.Count > 0)
        {
          int v = 1;
          Hashset<T> set = new Hashset<T>();
          T dq = q.Dequeue();
          set.Add(dq);

          Q value = cache2[dq];
          while (q.Count > 0 && cache2[q.Peek()].Equals(value))
          {
            set.Add(q.Dequeue());
            v++;
          }

          for (int i = 0; i < v; i++)
          {
            Pair<T, Q> min = ExtractMin();
            Assert.IsTrue(set.Contains(min.First));
            set.Remove(min.First);
          }
        }
      }
    }
  }
}