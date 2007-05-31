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
  }
}
