using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  [TestFixture]
  public class StrangeEntropyBlackboxTest : StrangeEntropyBlackboxTestBase
  {
    protected override double EPS
    {
      get { return 1e-5; }
    }

    [Test]
    public void Test_2LoopDot()
    {
      for (int p = 2; p < 20; p++)
      {
        for (int q = 2; q < 20; q++)
        {
          List<Node> ns = new List<Node>();
          int prev = p;
          for (int i = 0; i <= p; i++)
          {
            ns.Add(n(1 + prev, 1 + i));
            prev = i;
          }
          prev = p + q;
          for (int i = p; i <= p + q; i++)
          {
            ns.Add(n(1 + prev, 1 + i));
            prev = i;
          }

          double pp = L(1.0/2.0/(p + 1));
          double qq = L(1.0/2.0/(q + 1));
          double vv = L(1.0/2.0/(q + 1) + 1.0/2.0/(p + 1));

          try
          {
            DoTest("fnin", vv - pp - qq, ns.ToArray());
          } catch
          {
            Console.Out.WriteLine("p = {0}", p);
            Console.Out.WriteLine("q = {0}", q);
            throw;
          }
        }
      }
    }
  }
}