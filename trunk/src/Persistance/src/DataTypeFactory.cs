using System;
using System.Collections.Generic;

namespace DSIS.Persistance
{
  public enum DataClass : int
  {
    REF,
    INT,
  }

  public class DataTypeFactory {
    private static readonly List<IDataTypeFactory> myTypes = new List<IDataTypeFactory>();

    public static DataType Load(IBinaryReader reader)
    {
      int type;
      reader.Read(out type);

      DataClass clazz = (DataClass) type;
      foreach (IDataTypeFactory t in myTypes)
      {
        if (t.Match(clazz))
        {
          return t.Create(reader);
        } 
      }
      throw new Exception("Failed to load data");
    }
  }
}