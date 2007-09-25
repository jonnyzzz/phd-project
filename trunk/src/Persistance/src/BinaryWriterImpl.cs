using System.IO;

namespace DSIS.Persistance
{
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