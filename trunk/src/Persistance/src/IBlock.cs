using System.IO;

namespace DSIS.Persistance
{
  public interface IBinaryWriter
  {
    void WriteLong(long l);
    void WriteInt(int i);
    void WriteString(string s);
  }

  public interface IBinaryReader
  {
    int ReadInt();
    long ReadLong();
    string ReadString();
  }

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
  }
  
  public class BinaryWriterImpl : IBinaryWriter
  {
    private readonly BinaryWriter myWriter;

    public BinaryWriterImpl(BinaryWriter writer)
    {
      myWriter = writer;
    }

    public void WriteLong(long l)
    {
      myWriter.Write(l);
    }

    public void WriteInt(int i)
    {
      myWriter.Write(i);
    }

    public void WriteString(string s)
    {
      myWriter.Write(s);
    }
  }


}