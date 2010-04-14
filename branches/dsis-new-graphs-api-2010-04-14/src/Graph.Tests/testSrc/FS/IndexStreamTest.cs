using System.IO;
using System.Linq;
using DSIS.Graph.FS;
using DSIS.Persistance.Streams;
using NUnit.Framework;

namespace DSIS.Graph.Tests.FS
{
  [TestFixture]
  public class IndexStreamTest
  {
    [Test]
    public void TestEmptyStream()
    {
      var f = new Factory();

      var os = f.OutputStream();
      os.Dispose();
      IIndexInputStream r = f.InputStream();

      Assert.AreEqual(0, r.ReadData().Count());
    }

    private class Factory
    {
      private readonly MemoryStream myMemoryStream = new MemoryStream();

      public IIndexInputStream InputStream()
      {
        return new IndexInputStream(myMemoryStream.AsInputStream(x => x.Flush()));
      }

      public IIndexOutputStream OutputStream()
      {
        return new IndexOutputStream(myMemoryStream.AsOutputStream(x => x.Flush()));
      }
    }


    [Test]
    public void TestOneEntry()
    {
      var f = new Factory();
      var os = f.OutputStream();
      os.WriteBlockStartLocation(new IndexEntry {Begin = 1, Data = 10});
      os.Dispose();
      IIndexInputStream r = f.InputStream();

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
        var f = new Factory();
        var os = f.OutputStream();
        os.WriteBlockStartLocation(new IndexEntry {Begin = 1 << b, Data = 123 + 1 << b});
        os.Dispose();
        IIndexInputStream r = f.InputStream();

        Assert.AreEqual(1, r.ReadData().Count());
        IndexEntry first = r.ReadData().First();
        Assert.AreEqual(1 << b, first.Begin);
        Assert.AreEqual(123 + 1 << b, first.Data);

        Assert.AreEqual(first, r.GetAt(0));
      }
    }
  }
}