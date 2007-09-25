namespace DSIS.Persistance
{
  public interface IBinaryReader
  {
    void Read(out int v);
    void Read(out long v);
    void Read(out string s);

    long ReadLong();
  }
}