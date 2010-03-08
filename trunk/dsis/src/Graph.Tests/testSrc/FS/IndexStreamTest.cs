using System.IO;
using System.Linq;
using DSIS.Graph.FS;
using NUnit.Framework;

namespace DSIS.Graph.Tests.FS
{
  [TestFixture]
  public class IndexStreamTest
  {
    [Test]
    public void TestEmptyStream()
    {
      var os = new IndexOutputStream(new MemoryStream());
      os.Dispose();
      IndexInputStream r = os.Reader();

      Assert.AreEqual(0, r.ReadData().Count());
    }

    [Test]
    public void TestOneEntry()
    {
      var os = new IndexOutputStream(new MemoryStream());
      os.WriteBlockStartLocation(new IndexEntry {Begin = 1, Data = 10});
      os.Dispose();
      IndexInputStream r = os.Reader();

      Assert.AreEqual(1, r.ReadData().Count());
      IndexEntry first = r.ReadData().First();
      Assert.AreEqual(1, first.Begin);
      Assert.AreEqual(10, first.Data);

      Assert.AreEqual(first, r.GetAt(0));
    }

    [Test]
    public void TestWriteBitsEntry()
    {
      for (int b = 1; b < 62; b++)
      {
        var os = new IndexOutputStream(new MemoryStream());
        os.WriteBlockStartLocation(new IndexEntry {Begin = 1 << b, Data = 123 + 1 << b});
        os.Dispose();
        IndexInputStream r = os.Reader();

        Assert.AreEqual(1, r.ReadData().Count());
        IndexEntry first = r.ReadData().First();
        Assert.AreEqual(1 << b, first.Begin);
        Assert.AreEqual(123 + 1 << b, first.Data);

        Assert.AreEqual(first, r.GetAt(0));
      }
    }
  }
}