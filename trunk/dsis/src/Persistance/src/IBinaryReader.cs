using System;

namespace DSIS.Persistance
{
  public interface IBinaryReader : IDisposable
  {
    long ReadLong();
    int ReadInt();
    string ReadString();
    double ReadDouble();
  }

  public static class BinaryReaderHelpers
  {
    public static void Read(this IBinaryReader reader, out int v)
    {
      v = reader.ReadInt();      
    }

    public static void Read(this IBinaryReader reader, out long v)
    {
      v = reader.ReadLong();      
    }

    public static void Read(this IBinaryReader reader, out string v)
    {
      v = reader.ReadString();
    }

    public static void Read(this IBinaryReader reader, out double v)
    {
      v = reader.ReadDouble();
    }
  }
}