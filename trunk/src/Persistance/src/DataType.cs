namespace DSIS.Persistance
{
  public interface IDataTypeFactory
  {
    bool Match(DataClass code);
    DataType Create(IBinaryReader reader);
  }

  public abstract class DataType
  {
  }
}