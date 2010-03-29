using System;

namespace DSIS.Persistance
{
  public interface IBinaryWriter : IDisposable
  {
    void WriteDouble(double d);
    void WriteLong(long l);
    void WriteInt(int i);
    void WriteString(string s);
  }
}