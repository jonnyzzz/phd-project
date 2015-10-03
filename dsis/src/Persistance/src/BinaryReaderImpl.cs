using System.IO;

namespace DSIS.Persistance
{
  public class BinaryReaderImpl : IBinaryReader
  {
    private readonly BinaryReader myReader;

    public BinaryReaderImpl(BinaryReader reader)
    {
      myReader = reader;
    }

    public int ReadInt()
    {
      return myReader.ReadInt32();
    }

    public void Read(out int v)
    {
      throw new System.NotImplementedException();
    }

    public void Read(out long v)
    {
      throw new System.NotImplementedException();
    }

    public void Read(out string s)
    {
      throw new System.NotImplementedException();
    }

    public long ReadLong()
    {
      return myReader.ReadInt64();
    }

    public string ReadString()
    {
      return myReader.ReadString();
    }
  }
}