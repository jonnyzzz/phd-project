using NUnit.Framework;

namespace DSIS.Utils.Tests
{
  [TestFixture]
  public class LongConverterTest
  {
    [Test]
    public void TestLongConverter_0_to_100()
    {
      for(long i = 0; i <100; i ++)
      {
        byte[] b = LongConverter.ToBytes(i);
        Assert.AreEqual(b.Length, LongConverter.Size);

        long v = LongConverter.FromBytes(b, 0);
        Assert.AreEqual(v, i);
      }
    }

    [Test]
    public void TestLongConverter_min100_to_100()
    {
      for(long i = -100; i <100; i ++)
      {
        byte[] b = LongConverter.ToBytes(i);
        Assert.AreEqual(b.Length, LongConverter.Size);

        long v = LongConverter.FromBytes(b, 0);
        Assert.AreEqual(v, i);
      }
    }

    [Test]
    public void TestLongConverter_100k_to_103k()
    {
      for(long i = 100000; i <103000; i ++)
      {
        byte[] b = LongConverter.ToBytes(i);
        Assert.AreEqual(b.Length, LongConverter.Size);

        long v = LongConverter.FromBytes(b, 0);
        Assert.AreEqual(v, i);
      }
    }

    [Test]
    public void TestLongConverter_100m_to_100m3k()
    {
      const long m = 1000*1000;
      for(long i = m; i <m + 3000; i ++)
      {
        byte[] b = LongConverter.ToBytes(i);
        Assert.AreEqual(b.Length, LongConverter.Size);

        long v = LongConverter.FromBytes(b, 0);
        Assert.AreEqual(v, i);
      }
    }

    [Test]
    public void TestLongConverter_minus100m_to_100m3k()
    {
      const long m = 1000*1000;
      for(long i = -m; i <-m + 3000; i ++)
      {
        byte[] b = LongConverter.ToBytes(i);
        Assert.AreEqual(b.Length, LongConverter.Size);

        long v = LongConverter.FromBytes(b, 0);
        Assert.AreEqual(v, i);
      }
    }
  }
}