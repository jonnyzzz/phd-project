using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  [TestFixture]
  public class JVRMeasureTest : JVRMeasureTestBase
  {
    [Test]
    public void Test_F_One()
    {
      DoTest("f", n(1, 1, 1));
    }

    [Test]
    public void Test_F_Two()
    {
      DoTest("f", n(1, 1, 1), n(2, 2, 1));
    }

    [Test]
    public void Test_F_Two2()
    {
      DoTest("f", n(1, 2, 1), n(2, 1, 1));
    }

    [Test]
    public void Test_FI_One()
    {
      DoTest("fni", n(1, 1, 1));
    }

    [Test]
    public void Test_FI_Two()
    {
      DoTest("fni", n(1, 1, 1/2.0), n(2, 2, 1/2.0));
    }

    [Test]
    public void Test_FI_Two2()
    {
      DoTest("fni", n(1, 2, 1/2.0), n(2, 1, 1/2.0));
    }

    [Test]
    public void Test_FI_Three()
    {
      DoTest("fni", n(1, 2, 1/3.0), n(2, 1, 1/3.0), n(1, 1, 1/3.0));
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
      for(int i=0; i<N; i++)
      {
        for(int j=0; j<N; j++)
        {          
          ns.Add(n(i,j));
        }
      }

      DoTest("fni", 3.3219280948873489, ns.ToArray());
    }

    [Test]
    public void Test_OneLoop()
    {
      const int N = 2000;
      for(int i=1000; i<N; i++)
      {
        List<Node> ns = new List<Node>();
        for(int j=0; j<i; j++)
        {
          ns.Add(n(j, (j+1)%i));          
        }

        DoTest("fi", 0, ns.ToArray());
      }            
    }
    
    [Test]
    public void Test_TwoLoop_OnNode()
    {
      DEBUG = true;
      for(int i=10; i<200; i++)
      {
        List<Node> ns = new List<Node>();
        for(int j=0; j<i; j++)
        {
          ns.Add(n(j, (j+1)%i));          
          ns.Add(n(j + i - 1, (j+1)%i + i - 1));          
        }

        DoTest("fnin", /*(i + 1.0)/i*Math.Log(i,2) - 2.0/i - Math.Log(i+1,2)*/ 2.0/(i+1.0), ns.ToArray());
      }            
    }


    [Test]
    public void Test_Logistics()
    {
      DoTest("fnin", 1.5912074632572841d, n(0, 0),
             n(0,1),
             n(0,2),
             n(0,3),
             n(1,7),
             n(1,4),
             n(1,5),
             n(1,6),
             n(1,3),
             n(2,7),
             n(2,8),
             n(2,9),
             n(2,10),
             n(3,11),
             n(3,12),
             n(3,10),
             n(4,14),
             n(4,15),
             n(4,12),
             n(4,13),
             n(5,14),
             n(5,15),
             n(5,16),
             n(6,18),
             n(6,16),
             n(6,17),
             n(7,18),
             n(7,19),
             n(8,19),
             n(9,19),
             n(10,19),
             n(11,19),
             n(12,18),
             n(12,19),
             n(13,18),
             n(13,16),
             n(13,17),
             n(14,14),
             n(14,15),
             n(14,16),
             n(15,14),
             n(15,15),
             n(15,12),
             n(15,13),
             n(16,11),
             n(16,12),
             n(16,10),
             n(17,7),
             n(17,8),
             n(17,9),
             n(17,10),
             n(18,7),
             n(18,4),
             n(18,5),
             n(18,6),
             n(18,3),
             n(19,0),
             n(19,1),
             n(19,2),
             n(19,3)
        );
    }          
  }
}