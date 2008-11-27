namespace DSIS.Persistance
{
  public interface IPersistanceFactory
  {
    IBinaryWriter CreateWriter(string file);
    IBinaryReader CreateReader(string file);
  }
}