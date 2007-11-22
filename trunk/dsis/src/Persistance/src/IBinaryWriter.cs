namespace DSIS.Persistance
{
  public interface IBinaryWriter
  {
    void WriteLong(long l);
    void WriteInt(int i);
    void WriteString(string s);
  }
}