using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Core.System;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Utils;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.LineIterator.Tests
{
  [TestFixture]
  public class LineIteratorTest
  {
    private LineEx<LinePointImpl> myLine;

    [SetUp]
    public void SetUp()
    {
      myLine = new LineEx<LinePointImpl>(0.999999, new LinePointImpl(new double[] {0}));
      myLine.AddPointToEnd(new LinePointImpl(new double[] {1}));
    }

    [Test]
    public void Test_SetUp()
    {
      AssertPoints(1, "0", "1");
    }

    [Test]
    public void Test_const()
    {
      ISystemInfoAndSpaceProvider info = Create(d => d);        
      myLine.Iterate(info);

      AssertPoints(1, "0", "0.5", "1");
    }
    
    [Test]
    public void Test_const3()
    {
      myLine.AddPointToEnd(new LinePointImpl(new double[]{2}));

      ISystemInfoAndSpaceProvider info = Create(d => d);        
      myLine.Iterate(info);

      AssertPoints(2, "0", "0.5", "1", "1.5", "2");
    }

    [Test]
    public void Test_const_100()
    {
      List<string> gld = new List<string>();
      gld.Add("0");
      gld.Add("0.5");
      gld.Add("1");
      for (int i = 2; i <= 100; i++)
      {
        myLine.AddPointToEnd(new LinePointImpl(new double[] {i}));
        gld.Add((i-0.5).ToString("R", CultureInfo.InvariantCulture));
        gld.Add(((double)i).ToString("R", CultureInfo.InvariantCulture));
      }

      ISystemInfoAndSpaceProvider info = Create(d => d);
      myLine.Iterate(info);

      AssertPoints(100, gld.ToArray());
    }
    
    [Test]
    public void Test_const_100x2()
    {      
      for (int i = 2; i <= 100; i++)
      {
        myLine.AddPointToEnd(new LinePointImpl(new double[] {i}));
      }

      ISystemInfoAndSpaceProvider info = Create(d => 2*d);
      myLine.Iterate(info);

      AssertPoints(200, Gold(0, 200.1, 0.5));
    }
    
    [Test]
    public void Test_const_100x0_5()
    {      
      for (int i = 2; i <= 100; i++)
      {
        myLine.AddPointToEnd(new LinePointImpl(new double[] {i}));
      }

      ISystemInfoAndSpaceProvider info = Create(d => 0.5*d);
      myLine.Iterate(info);

      AssertPoints(50, Gold(0, 50.1, 0.5));
    }

    [Test]
    public void Test_2x()
    {
      ISystemInfoAndSpaceProvider info = Create(d => 2*d);
      myLine.Iterate(info);

      AssertPoints(2,"0", "0.5", "1", "1.5", "2");
    } 
    
    [Test]
    public void Test_0_5x()
    {
      ISystemInfoAndSpaceProvider info = Create(d => 0.5*d);
      myLine.Iterate(info);

      AssertPoints(0.5, "0", "0.5");
    }
    
    [Test]
    public void Test_2x3()
    {
      myLine.AddPointToEnd(new LinePointImpl(new double[] { 2 }));
      ISystemInfoAndSpaceProvider info = Create(d => 2*d);
      myLine.Iterate(info);

      AssertPoints(4,"0", "0.5", "1", "1.5", "2","2.5", "3", "3.5", "4");
    }

    [Test]
    public void Test_0_5x3()
    {
      myLine.AddPointToEnd(new LinePointImpl(new double[] { 2 }));
      ISystemInfoAndSpaceProvider info = Create(d => 0.5*d);
      myLine.Iterate(info);

      AssertPoints(1,"0", "0.5", "1");
    }


    [Test]
    public void Test_Pefomance_0_5()
    {
      ISystemInfoAndSpaceProvider info = Create(d => 0.5*d);
      for (int i = 0; i < 1000000; i++)
        myLine.AddPointToEnd(new LinePointImpl(new double[] {i}));

      myLine.Iterate(info);
    }


    private static ISystemInfoAndSpaceProvider Create(Converter<double, double> function)
    {
      return new MockSystemInfo<double>(delegate(double[] ins, double[] outs) { outs[0] = function(ins[0]); },
                                   new MockSystemSpace(1, 0, 1000, 1000));
            
    }

    private static string[] Gold(double start, double stop, double step)
    {
      var list = new List<string>();
      while(start <= stop)
      {
        list.Add(start.ToString("R", CultureInfo.InvariantCulture));
        start += step;
      }
      return list.ToArray();
    }

    private void AssertPoints(double length, params string[] gld)
    {
      try
      {
        Assert.That(myLine.Length, Is.EqualTo(length));
      } catch(Exception e)
      {
        Console.Out.WriteLine("myLine.Length = {0}", myLine.Length);
        try
        {
          AssertPoints();
        } catch
        {
          ;
        }
        throw new Exception(e.Message, e);
      }

      AssertPoints(gld);
    }

    private void AssertPoints(params string[] gld)
    {
      var sw = new StringWriter(CultureInfo.InvariantCulture);
      myLine.Save(sw);

      try
      {

        string[] save = sw.ToString().Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);

        Assert.That(save.Length, Is.EqualTo(gld.Length));
        for (int i = 0; i < gld.Length; i++)
        {
          Assert.That(save[i].Trim(), Is.EqualTo(gld[i].Trim()));
        }
      } catch(Exception e)
      {
        Console.Out.WriteLine("sw = \r\n{0}", sw);
        throw new Exception(e.Message, e);
      }
    }

    private class LineEx<T> : Line<T> where T : ILinePoint<T>
    {
      public LineEx(double eps, T initial)
        : base(eps.Fill(initial.Dimension), initial)
      {
      }

      public void Iterate(ISystemInfoAndSpaceProvider prov)
      {
        Iterate(prov.SystemSpace, prov);
      }
    }
  }
}