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
      CollectionAssert.AreEqual(messages, myLog);
    }

    public static  void Clear()
    {
      myLog.Clear();
    }
  }
}