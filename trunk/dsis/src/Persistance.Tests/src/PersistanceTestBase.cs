using System.IO;

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
      using(var wr = new BinaryWriterImpl(new BinaryWriter(stream)))
        ser(wr, x);

      stream.Flush();
      stream.Close();

      stream = new MemoryStream(stream.GetBuffer());

      T loaded;
      using(var r = new BinaryReaderImpl(new BinaryReader(stream)))
        loaded = des(r);

      assert(x, loaded);
    }
  }
}