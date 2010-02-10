using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace DSIS.Persistance.Tests
{
  public abstract class PersistanceTestBase
  {
    protected delegate void Serialize<T>(IBinaryWriter w, T x);

    protected delegate T DeSerialized<T>(IBinaryReader w);

    protected delegate void Assert<T>(T orig, T loaded);

    protected static void DoTest<T>(T x, Serialize<T> ser, DeSerialized<T> des, Assert<T> assert)
    {
      var stream = new MemoryStream();
      using (var wr = new BinaryWriterImpl(new BinaryWriter(stream)))
        ser(wr, x);

      stream.Flush();
      stream.Close();

      stream = new MemoryStream(stream.GetBuffer());

      T loaded;
      using (var r = new BinaryReaderImpl(new BinaryReader(stream)))
        loaded = des(r);

      assert(x, loaded);
    }

    protected static void DoTest2<T>(T x, Serialize<T> ser, DeSerialized<T> des, Assert<T> assert)
    {

      var wr = new Writer();
        ser(wr, x);

      T loaded = des(new Reader(wr.myData.GetEnumerator()));

      assert(x, loaded);
    }

    private class Reader : IBinaryReader
    {
      private readonly IEnumerator<object> myData;
      private int myOffset = 0;

      public Reader(IEnumerator<object> data)
      {
        myData = data;
      }

      public void Read(out int v)
      {
        v = ReadInt();
      }

      public void Read(out long v)
      {
        v = ReadLong();
      }

      public void Read(out string s)
      {
        s = ReadString();
      }

      public void Read(out double v)
      {
        v = ReadDouble();
      }

      public long ReadLong()
      {
        myOffset++;
        myData.MoveNext();
        Assert.IsTrue(myData.Current.GetType() == typeof (long));
        return (long) myData.Current;
      }

      public int ReadInt()
      {
        myOffset++;
        myData.MoveNext();
        Assert.IsTrue(myData.Current.GetType() == typeof (int));
        return (int) myData.Current;
      }

      public string ReadString()
      {
        myOffset++;
        myData.MoveNext();
        Assert.IsTrue(myData.Current.GetType() == typeof (string));
        return (string) myData.Current;
      }

      public double ReadDouble()
      {
        myOffset++;
        myData.MoveNext();
        Assert.IsTrue(myData.Current.GetType() == typeof (double));
        return (double) myData.Current;
      }

      public void Dispose()
      {
      }
    }

    private class Writer : IBinaryWriter
    {
      public readonly List<object> myData = new List<object>();

      public void WriteDouble(double d)
      {
        myData.Add(d);
      }

      public void WriteLong(long l)
      {
        myData.Add(l);
      }

      public void WriteInt(int i)
      {
        myData.Add(i);
      }

      public void WriteString(string s)
      {
        myData.Add(s);
      }

      public void Dispose()
      {
      }
    }
  }
}