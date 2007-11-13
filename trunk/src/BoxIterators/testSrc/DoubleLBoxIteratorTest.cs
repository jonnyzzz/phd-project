using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.BoxIterators
{
  [TestFixture]
  public class DoubleLBoxIteratorTest
  {
    [Test]
    public void Test_01()
    {
      DoubleLBoxIterator it = new DoubleLBoxIterator(new double[] {1});
      IEnumerable<double[]> itt = it.EnumerateSteps(new double[]{0}, new double[]{1}, new double[1]);
      List<double> l = new List<double>();
      foreach (double[] doubles in itt)
      {
        l.Add(doubles[0]);
      }

      Assert.AreEqual(2, l.Count);
      Assert.IsTrue(l.Contains(0));
      Assert.IsTrue(l.Contains(1));
    }
    
    [Test]
    public void Test_02()
    {
      DoubleLBoxIterator it = new DoubleLBoxIterator(new double[] {1,1});
      IEnumerable<double[]> itt = it.EnumerateSteps(new double[]{0,5}, new double[]{2,7}, new double[2]);
      List<double> l = new List<double>();
      foreach (double[] doubles in itt)
      {
        l.Add(doubles[0] + doubles[1]*10);
      }

      Assert.AreEqual(9, l.Count);
      Assert.IsTrue(l.Contains(50));
      Assert.IsTrue(l.Contains(60));
      Assert.IsTrue(l.Contains(70));
      Assert.IsTrue(l.Contains(51));
      Assert.IsTrue(l.Contains(61));
      Assert.IsTrue(l.Contains(71));
      Assert.IsTrue(l.Contains(52));
      Assert.IsTrue(l.Contains(62));
      Assert.IsTrue(l.Contains(72));
    }
  }
}
