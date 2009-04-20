using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace DSIS.Utils.Tests
{
  [TestFixture]
  public class BinTreePriorityQueueExTestScenario : BinTreePriorityQueueExTestBase<string, double, BinTreePriorityQueueExTestScenario.Queue2> {
    private const string TEST_DATA = "testData/binTreeEx";

    protected override Queue2 Create()
    {
      return new Queue2();
    }
    /*
    [Test] public void Test_x000() { DoScriptTest("dump_0.txt");}
    [Test] public void Test_x001() { DoScriptTest("dump_1.txt");}
    [Test] public void Test_x002() { DoScriptTest("dump_2.txt");}
    [Test] public void Test_x003() { DoScriptTest("dump_3.txt");}
    [Test] public void Test_x004() { DoScriptTest("dump_4.txt");}
    [Test] public void Test_x005() { DoScriptTest("dump_5.txt");}
    [Test] public void Test_x006() { DoScriptTest("dump_6.txt");}
    [Test] public void Test_x007() { DoScriptTest("dump_7.txt");}
    [Test] public void Test_x008() { DoScriptTest("dump_8.txt");}
    [Test] public void Test_x009() { DoScriptTest("dump_9.txt");}
    [Test] public void Test_x010() { DoScriptTest("dump_10.txt");}
    [Test] public void Test_x011() { DoScriptTest("dump_11.txt");}
    [Test] public void Test_x012() { DoScriptTest("dump_12.txt");}
    [Test] public void Test_x013() { DoScriptTest("dump_13.txt");}
    [Test] public void Test_x014() { DoScriptTest("dump_14.txt");}
    [Test] public void Test_x015() { DoScriptTest("dump_15.txt");}
    [Test] public void Test_x016() { DoScriptTest("dump_16.txt");}
    [Test] public void Test_x017() { DoScriptTest("dump_17.txt");}
    [Test] public void Test_x018() { DoScriptTest("dump_18.txt");}
    [Test] public void Test_x019() { DoScriptTest("dump_19.txt");}
    [Test] public void Test_x020() { DoScriptTest("dump_20.txt");}
    [Test] public void Test_x021() { DoScriptTest("dump_21.txt");}
    [Test] public void Test_x022() { DoScriptTest("dump_22.txt");}
    [Test] public void Test_x023() { DoScriptTest("dump_23.txt");}    
    [Test] public void Test_x024() { DoScriptTest("dump_24.txt");}   
     * */
    
    private void DoScriptTest(string script)
    {
      string sc = Path.Combine(GetTestDataPath(), script);
      queue.ScriptTest(File.ReadAllText(sc), Converter);
    }

    private string GetTestDataPath()
    {
      string location = GetType().Assembly.Location;
      string path = Path.GetDirectoryName(new Uri(location).LocalPath);
      while (path != null && Directory.Exists(path))
      {
        string tmp = Path.Combine(path, TEST_DATA);
        if (Directory.Exists(tmp))
          return tmp;
        path = Path.GetDirectoryName(path);
      }
      throw new Exception("Unable to find data path");
    }

    private static Queue2.Action Converter(string input)
    {
      input = input.Substring(input.IndexOf('.')+1).Trim();

      if (input.StartsWith("Dump"))
        return new Queue.Action(Queue.ActionType.Dump);
      else if (input.StartsWith("Break"))
        return new Queue.Action(Queue.ActionType.Break);
      else
      {
        int v = int.Parse(input.Substring(5, 1));
        double d = double.Parse(input.Split('|')[1].Trim().Replace(',', '.'));
        if (input.StartsWith("Max"))
          return new Queue.Action(Queue.ActionType.Max, d, v.ToString());
        else if (input.StartsWith("Add ["))
          return new Queue.Action(Queue.ActionType.Add, d, v.ToString());
        else
          return new Queue.Action(Queue.ActionType.Remove, d, v.ToString());
      }
    }

    public class Queue2 : BinTreePriorityQueueExTestBase<string,double,Queue2>.Queue
    {
      public Queue2() : base(new Comparer())
      {
      }
    }

    private class Comparer : IComparer<double>
    {
      public int Compare(double x, double y)
      {
        x = Math.Abs(x);
        y = Math.Abs(y);

        if (x < y)
          return 1;
        if (x > y)
          return -1;
        return 0;
      }
    }    
  }
}