﻿using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Tests.FS
{
  [TestFixture]
  public class FSGraphTest : FSGraphTestBase
  {
    [Test]
    public void TestOneNodeGraph()
    {
      TestGraphEdgesBuilt(e(p(1,1)));
    }

    [Test]
    public void TestTwoNodesGraph()
    {
      TestGraphEdgesBuilt(e(p(1,1,2), p(2,2,1)));
    }    
    
    [Test]
    public void TestThreeNodesGraph()
    {
      TestGraphEdgesBuilt(e(p(1,1,2,3), p(2,2,1,3), p(3,3,2,1)));
    }    

    [Test]
    public void TestTenNodesGraph()
    {
      TestGraphEdgesBuilt(e(p(1,2), p(2,3), p(3,4), p(4,5), p(5,6), p(6,7), p(7,8), p(8,9), p(9,10), p(10, 1)));
    }    

    [Test]
    public void TestGraphDataHolder_Long()
    {
      TestGraphDataHolder(e(p(1), p(2)), e(Pair.Of(1, 5L), Pair.Of(2, 7L)));
    }
    
    [Test]
    public void TestGraphDataHolder_Uint()
    {
      TestGraphDataHolder(e(p(1), p(2)), e(Pair.Of(1, (uint)5), Pair.Of(2, (uint)7)));
    }
  }
}