using System;
using DSIS.Persistance;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Core.System.Impl
{
  [ComponentImplementation]
  public class DefaultSystemSpacePersistance : IPersistance<ISystemSpace>
  {
    public ISystemSpace Load(IBinaryReader reader)
    {
      if (reader.ReadString() != Key())
        throw new ArgumentException("Key was expected");

      var dim = reader.ReadInt();
      var left = new double[dim];
      var right = new double[dim];
      var grid = new long[dim];

      for (var i = 0; i < dim; i++)
      {
        reader.Read(out left[i]);
        reader.Read(out right[i]);
        reader.Read(out grid[i]);
      }

      return new DefaultSystemSpace(dim, left, right, grid);
    }

    public void Save(ISystemSpace info, IBinaryWriter writer)
    {
      writer.WriteString(Key());
      writer.WriteInt(info.Dimension);
      for (int i = 0; i < info.Dimension; i++)
      {
        writer.WriteDouble(info.AreaLeftPoint[i]);
        writer.WriteDouble(info.AreaRightPoint[i]);
        writer.WriteLong(info.InitialSubdivision[i]);
      }
    }

    private static string Key()
    {
      return "Default SYSTEM SPACE";
    }    
  }
}