namespace DSIS.Persistance
{
  public abstract class DataTypeBase<TInh> : DataType where TInh : DataTypeBase<TInh>, new()
  {
    protected abstract void Load(IBinaryReader rdr);

    protected class Factory : IDataTypeFactory
    {
      public bool Match(DataClass code)
      {
        return code == DataClass.REF;
      }

      public DataType Create(IBinaryReader reader)
      {
        TInh type = new TInh();
        type.Load(reader);
        return type;
      }
    }
  }
}