using System.Collections.Generic;
using DSIS.SimpleRunner.ImageEntropy.ForkJoin;
using DSIS.Utils;
using NUnit.Framework;
using System.Linq;

namespace DSIS.SimpleRunner.Test.ImageEntropy.ForkJoin
{
  [TestFixture]
  public class ForkJoinSlicerTest
  {
    private ForkJoinSlicer mySlicer = new ForkJoinSlicer();

    [Test]
    public void Test_Slice_Overlap_0()
    {
      Assert.AreEqual("0->9, 10->19, 20->29, 30->39, 40->50", ToString(mySlicer.SliceRow(0, 50, 10, 0)));
    }

    [Test]
    public void Test_Slice_Overlap_1()
    {
      Assert.AreEqual("0->10, 10->20, 20->30, 30->40, 40->50", ToString(mySlicer.SliceRow(0, 50, 10, 1)));
    }

    [Test]
    public void Test_Slice_Overlap_2()
    {
      Assert.AreEqual("0->11, 10->21, 20->31, 30->41, 40->50", ToString(mySlicer.SliceRow(0, 50, 10, 2)));
    }

    private static string ToString(IEnumerable<Pair<int, int>> sliceRow)
    {
      return string.Join(", ", sliceRow.Select(x => string.Format("{0}->{1}", x.First, x.Second)));
    }


  }
}