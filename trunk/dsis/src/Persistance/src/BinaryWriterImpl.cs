using System;
using System.IO;

namespace DSIS.Persistance
{
  public class BinaryWriterImpl : IBinaryWriter, IDisposable
  {
    private readonly BinaryWriter myWriter;

    public BinaryWriterImpl(BinaryWriter writer)
    {
      myWriter = writer;
    }

    public void WriteDouble(double d)
    {
      myWriter.Write(d);
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

    public void Close()
    {
      myWriter.Close();
    }

    public void Dispose()
    {
      Close();
    }
  }
}