using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.BoxIterators.Generator
{
  [TestFixture]
  public class BoxIteratorGeneratorTest
  {
    [Test]
    public void Test_01()
    {
      IBoxIterator<int> iterator = BoxIteratorGenerator<int>.GenerateIterator(1);
      int[] l = {777};
      int[] r = {555};
      int[] t = new int[1];

      IEnumerator<int[]> enumerable = iterator.EnumerateBox(l, r, t).GetEnumerator();

      Assert.IsTrue(enumerable.MoveNext());
      Assert.AreEqual(777, enumerable.Current[0]);
      Assert.IsTrue(enumerable.MoveNext());
      Assert.AreEqual(555, enumerable.Current[0]);
      Assert.IsFalse(enumerable.MoveNext());
    }

    [Test]
    public void Test_02()
    {
      IBoxIterator<int> iterator = BoxIteratorGenerator<int>.GenerateIterator(2);
      int[] l = { 777, 222 };
      int[] r = { 555, 444 };
      int[] t = new int[2];

      IEnumerator<int[]> enumerable = iterator.EnumerateBox(l, r, t).GetEnumerator();

      Assert.IsTrue(enumerable.MoveNext());
      Assert.AreEqual(777, enumerable.Current[0]);
      Assert.AreEqual(222, enumerable.Current[1]);

      Assert.IsTrue(enumerable.MoveNext());
      Assert.AreEqual(555, enumerable.Current[0]);
      Assert.AreEqual(222, enumerable.Current[1]);

      Assert.IsTrue(enumerable.MoveNext());
      Assert.AreEqual(555, enumerable.Current[0]);
      Assert.AreEqual(444, enumerable.Current[1]);

      Assert.IsTrue(enumerable.MoveNext());
      Assert.AreEqual(777, enumerable.Current[0]);
      Assert.AreEqual(444, enumerable.Current[1]);

      Assert.IsFalse(enumerable.MoveNext());
    }
  }
}