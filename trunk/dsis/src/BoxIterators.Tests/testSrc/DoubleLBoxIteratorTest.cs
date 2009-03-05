using System;
using System.Collections.Generic;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.BoxIterators.Tests
{
  [TestFixture]
  public class DoubleLBoxIteratorTest
  {
    /// <summary>
    /// This method tests the idea of point method for points
    /// </summary>
    [Test]
    public void Test_Range()
    {
      for (int n = 3; n < 10; n++)
      {
        for (double x = 1; x > 1e-8; x /= Math.Sqrt(2))
        {
          var it = new DoubleLBoxIterator(new[] {x}, new[] {n});
          var itt = it.EnumerateSteps(new double[] {0}, new[] {x}, new double[1]);
          var l = new List<double>();
          foreach (var doubles in itt)
          {
            l.Add(doubles[0]);
          }
          var log = string.Format("At x = {0:R}, n = {1}, but was: [{2}]", x, n, l.JoinString(e => e.ToString("R"), ";"));

          Assert.AreEqual(x, l.FoldLeft(l[0], Math.Max), 1e-10, log);
          Assert.AreEqual(0, l.FoldLeft(l[0], Math.Min), 1e-10, log);
          Assert.AreEqual(n, l.Count, log);
        }
      }
    }


    /// <summary>
    /// This method tests the idea of point method for points
    /// </summary>
    [Test]
    public void Test_Range2()
    {
      for (double y = -10; y < 10; y+= Math.Sqrt(2))
      {
        for (int n = 3; n < 10; n++)
        {
          for (double x = 1; x > 1e-8; x /= Math.Sqrt(3))
          {
            var it = new DoubleLBoxIterator(new[] {x}, new[] {n});
            var l = new List<double>();
            foreach (var doubles in it.EnumerateSteps(new[] {y}, new[] {x+y}, new double[1]))
            {
              l.Add(doubles[0]);
            }
            var log = string.Format("At x = {0:R}, y = {3:R},  n = {1}, but was: [{2}]", x, n, l.JoinString(e => e.ToString("R"), ";"), y);

            Assert.AreEqual(x+y, l.FoldLeft(l[0], Math.Max), 1e-10, log);
            Assert.AreEqual(y, l.FoldLeft(l[0], Math.Min), 1e-10, log);
            Assert.AreEqual(n, l.Count, log);
          }
        }
      }
    }

    /// <summary>
    /// This method tests the idea of point method for points
    /// </summary>
    [Test]
    public void Test_5_half()
    {
      var n = 4;
      var x = 1/Math.Sqrt(2)/Math.Sqrt(2);
      var it = new DoubleLBoxIterator(x.Fill(1), n.Fill(1));
      var itt = it.EnumerateSteps(new double[] {0}, new[] {x}, new double[1]);
      var l = new List<double>();
      foreach (var doubles in itt)
      {
        l.Add(doubles[0]);
      }
      var log = string.Format("At x = {0:R}, n = {1}, but was: [{2}]", x, n, l.JoinString(e => e.ToString("R"), ";"));

      Assert.AreEqual(x, l.FoldLeft(l[0], Math.Max), 1e-10, log);
      Assert.AreEqual(0, l.FoldLeft(l[0], Math.Min), 1e-10, log);
      Assert.AreEqual(n, l.Count, log);
    }
  }
}