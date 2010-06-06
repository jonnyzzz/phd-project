using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace DSIS.Persistance.Tests
{
  [TestFixture]
  public class DiskCacheTest : PersistanceTestBase, IPersistance<int>, IPersistanceFactory
  {
    private DiskCache<int, int> cache;
    private Dictionary<string, MemoryStream> myStreams;
    private string myReadCalls;
    private string myWriteCalls;

    [SetUp]
    public void SetUp()
    {
      myStreams = new Dictionary<string, MemoryStream>();
      cache = new DiskCache<int, int>(this, this, "A");
      myReadCalls = "";
      myWriteCalls = "";
    }

    [TearDown]
    public void TearDown()
    {
      myStreams = null;
      cache = null;
    }

    [Test]
    public void Test_01()
    {
      cache.AddItem(1,1);
      cache.AddItem(2,2);
      cache.AddItem(3,3);

      EnforceClean();

      Assert.AreEqual(1,cache.GetItem(1));
      Assert.AreEqual(2,cache.GetItem(2));
      Assert.AreEqual(3,cache.GetItem(3));

      Assert.That(myReadCalls, Is.EqualTo("A\\DiskCache_Int32_1.cache|A\\DiskCache_Int32_2.cache|A\\DiskCache_Int32_3.cache|"));
      Assert.That(myWriteCalls, Is.EqualTo("A\\DiskCache_Int32_1.cache|A\\DiskCache_Int32_2.cache|A\\DiskCache_Int32_3.cache|"));
    }

    
    [Test]
    public void Test_02()
    {
      cache.AddItem(1,1);
      cache.AddItem(2,2);
      cache.AddItem(3,3);

      Assert.AreEqual(1,cache.GetItem(1));
      Assert.AreEqual(2,cache.GetItem(2));
      Assert.AreEqual(3,cache.GetItem(3));

      Assert.That(myReadCalls, Is.EqualTo(""));
      Assert.That(myWriteCalls, Is.EqualTo("A\\DiskCache_Int32_1.cache|A\\DiskCache_Int32_2.cache|A\\DiskCache_Int32_3.cache|"));
    }

    public void Save(int t, IBinaryWriter wr)
    {
      wr.WriteInt(t);
    }

    public int Load(IBinaryReader reader)
    {
      return reader.ReadInt();
    }

    public IBinaryWriter CreateWriter(string file)
    {
      myWriteCalls += file + "|";
      var ms = new MemoryStream();
      myStreams.Add(file,ms);
      return new BinaryWriterImpl(new BinaryWriter(ms));
    }

    public IBinaryReader CreateReader(string file)
    {
      myReadCalls += file + "|";
      var ms = myStreams[file];
      return new BinaryReaderImpl(new BinaryReader(new MemoryStream(ms.GetBuffer())));
    }

    private static void EnforceClean()
    {
      Collect();
    }

    private static void Collect()
    {
      GC.Collect(GC.MaxGeneration);
      GC.WaitForPendingFinalizers();
      GC.Collect(GC.MaxGeneration);
      GC.WaitForPendingFinalizers();
    }
  }
}