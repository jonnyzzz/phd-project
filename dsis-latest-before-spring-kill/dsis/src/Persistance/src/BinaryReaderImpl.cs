using System;
using System.IO;

namespace DSIS.Persistance
{
  public class BinaryReaderImpl : IBinaryReader, IDisposable
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