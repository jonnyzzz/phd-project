using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod.Test
{
  [TestFixture]
  public class DictionaryTest
  {
    [Test]
    public void Test_01()
    {
      Dictionary<int, double[]> ds = new Dictionary<int, double[]>();
      ds[0] = new double[5];
      ds[0] = null;

      Assert.IsNull(ds[0]);
    }
  }
}