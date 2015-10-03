using System;

namespace DSIS.Persistance
{
  public interface IBinaryReader : IDisposable
  {
    void Read(out int v);
    void Read(out long v);
    void Read(out string s);
    void Read(out double v);

    long ReadLong();
    int ReadInt();
    string ReadString();
    double ReadDouble();
  }
}