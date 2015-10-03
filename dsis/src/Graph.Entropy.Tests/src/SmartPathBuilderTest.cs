using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  [TestFixture]
  public class SmartPathBuilderTest : SmartPathBuilderTestBase
  {
    [Test]
    public void Test_F_One()
    {
      DoTest("f", n(1, 1, 1));
    }

    [Test]
    public void Test_F_Two2()
    {
      DoTest("f", n(1, 2, 1), n(2, 1, 1));
    }

    [Test]
    public void Test_F_Two()
    {
      DoTest("f", n(1, 1, 1), n(2, 2, 1));
    }

    [Test]
    public void Test_FI_One()
    {
      DoTest("fni", n(1, 1, 1));
    }

    [Test]
    public void Test_FI_Two2()
    {
      DoTest("fni", n(1, 2, 1), n(2, 1, 1));
    }

    [Test]
    public void Test_FI_Three()
    {
      DoTest("fni", n(1, 2, 1), n(2, 1, 1), n(1, 1, 1));
    }

    [Test]
    public void Test_Ampi()
    {
      DoTest("fni", 0.2215, n(1, 2), n(2, 3), n(3, 5), n(5, 1), n(3, 8),
             n(8, 7), n(7, 6), n(6, 2));
    }

    [Test]
    public void Test_BigFull()
    {
      List<Node> ns = new List<Node>();
      const int N = 10;
      for (int i = 0; i < N; i++)
      {
        for (int j = 0; j < N; j++)
        {
          ns.Add(n(i, j));
        }
      }

      DoTest("fni", 3.2718920532720479d, ns.ToArray());
    }

    [Test]
    public void Test_OneLoop()
    {
      const int N = 2200;
      for (int i = 2000; i < N; i++)
      {
        List<Node> ns = new List<Node>();
        for (int j = 0; j < i; j++)
        {
          ns.Add(n(j, (j + 1) % i));
        }

        DoTest("fi", 0, ns.ToArray());
      }
    }

  }
}