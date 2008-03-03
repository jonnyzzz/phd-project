using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.Scheme2.Tests.testData
{
  public static class TestGraphRegistry
  {
    private static readonly List<string> myLog = new List<string>();

    public static void Log(string msg)
    {
      myLog.Add(msg);
    }

    public static void AssertData(params string[] messages)
    {
      try
      {
        CollectionAssert.AreEqual(messages, myLog);
      } catch (Exception e)
      {
        Console.Out.WriteLine("Actual messages:");
        foreach (string s in myLog)
        {
          Console.Out.WriteLine(s);
        }
        throw new Exception(e.Message, e);
      }
    }

    public static  void Clear()
    {
      myLog.Clear();
    }
  }
}