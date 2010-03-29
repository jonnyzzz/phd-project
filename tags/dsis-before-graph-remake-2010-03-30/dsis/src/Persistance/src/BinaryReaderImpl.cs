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

    public long ReadLong()
    {
      return myReader.ReadInt64();
    }

    public string ReadString()
    {
      return myReader.ReadString();
    }

    public double ReadDouble()
    {
      return myReader.ReadDouble();
    }

    public void Dispose()
    {
      Close();
    }

    public void Close()
    {
      myReader.Close();
    }
  }
}