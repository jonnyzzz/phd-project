using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Graph.Abstract;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using DSIS.Utils;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class TarjanGraphTest : GraphTestBase<TarjanGraph<IntegerCoordinate>, TarjanNode<IntegerCoordinate>>
  {
    protected override TarjanGraph<IntegerCoordinate> CreateGraph(IntegerCoordinateSystem ics)
    {
      return new TarjanGraph<IntegerCoordinate>(ics);
    }

    [Test]
    public void Test_NodeData_01()
    {
      n(4);
      using (var xxx = (myGraph).CreateDataHolder(x => 1))
      {
        n(1);
        n(2);
        n(3);

        Assert.That(xxx.GetData(an(1)), Is.EqualTo(1));
        Assert.That(xxx.GetData(an(2)), Is.EqualTo(1));
        Assert.That(xxx.GetData(an(3)), Is.EqualTo(1));
        Assert.That(xxx.GetData(an(4)), Is.EqualTo(1));
      }      
    }
    
    [Test]
    public void Test_NodeData_02()
    {
      n(4);
      using (var xxx = (myGraph).CreateDataHolder(x => 1))
      {
        xxx.SetData(n(1), 2);
        xxx.SetData(n(2), 3);
        xxx.SetData(n(3), 4);

        Assert.That(xxx.HasData(an(4)), Is.False);
        Assert.That(xxx.GetData(an(1)), Is.EqualTo(2));
        Assert.That(xxx.GetData(an(2)), Is.EqualTo(3));
        Assert.That(xxx.GetData(an(3)), Is.EqualTo(4));
        Assert.That(xxx.GetData(an(4)), Is.EqualTo(1));
      }      
    }

    [Test]
    public void Test_SelfLoop()
    {
      n(1, 1);
      Assert.That(myGraph.IsSelfLoop(an(1)), Is.True);
    }

    [Test]
    public void Test_SelfLoop2()
    {
      for (int i = 0; i < 1000; i++ )
        n(i, i);

      for (int i = 0; i < 1000; i++)
        Assert.That(myGraph.IsSelfLoop(an(i)), Is.True);
    }

    [Test]
    public void Test_SelfLoop3()
    {
      for (int i = 0; i < 1000; i++)
      {
        n(i);
        if (i%3 == 0)
          n(i, i);
      }

      for (int i = 0; i < 1000; i++)
        Assert.That(myGraph.IsSelfLoop(an(i)), Is.EqualTo(i % 3 == 0));
    }

    [Test]
    public void Test_SelfLoop4_AndUnusedFlag()
    {
      using (var xxx = myGraph.CreateNodeFlagsHolder("AAA"))
      {
        for (int i = 0; i < 1000; i++)
        {
          n(i);
          if (i%3 == 0)
            n(i, i);
        }

        for (int i = 0; i < 1000; i++)
        {
          Assert.That(myGraph.IsSelfLoop(an(i)), Is.EqualTo(i%3 == 0));
          Assert.That(xxx.GetData(an(i)), Is.False);
        }
      }
    }

    [Test]
    public void Test_SelfLoop5_AndusedFlag()
    {
      using (var xxx = myGraph.CreateNodeFlagsHolder("AAA"))
      {
        for (int i = 0; i < 1000; i++)
        {
          n(i);
          if (i%3 == 0)
            n(i, i);
          if (i%7 == 0)
            xxx.SetData(n(i), true);
        }

        for (int i = 0; i < 1000; i++)
        {
          Assert.That(myGraph.IsSelfLoop(an(i)), Is.EqualTo(i%3 == 0));
          Assert.That(xxx.GetData(an(i)), Is.EqualTo(i%7 == 0));
        }
      }
    }

    [Test]
    public void Test_MoreFlags()
    {
      var list = new List<IGraphDataHoler<bool, TarjanNode<IntegerCoordinate>>>();

      try
      {
        for (int i = 0;; i++)
        {
          list.Add(myGraph.CreateNodeFlagsHolder(i.ToString()));
        }
      }
      catch (Exception e)
      {
        //expected
      }

      Assert.That(list.Count, Is.EqualTo(7));

      var flags = new List<uint>
        (
        list.Cast<FlagsNodeHolder<TarjanGraph<IntegerCoordinate>, TarjanNode<IntegerCoordinate>, IntegerCoordinate>>().
          Map(x => x.Flag.Flag));
      flags.Sort();
      uint? v = null;
      foreach (var flag in flags)
      {
        Assert.That(v, Is.Not.EqualTo(flag));
        Console.Out.WriteLine("flag = {0:x}", flag);
        v = flag;
      }
    }
  }
}