using DSIS.Core.Coordinates;
using DSIS.Persistance;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.IntegerCoordinates.Generated
{
  [ComponentImplementation]
  public class IntegerCoordinatePersistanceProxy : IPersistance<ICellCoordinateSystem>
  {
    private readonly IntegerCoordinatePersistance myPersistance;

    public IntegerCoordinatePersistanceProxy(IntegerCoordinatePersistance persistance)
    {
      myPersistance = persistance;
    }

    public void Save(ICellCoordinateSystem t, IBinaryWriter wr)
    {
      myPersistance.Save((IIntegerCoordinateSystem) t, wr);
    }

    public ICellCoordinateSystem Load(IBinaryReader reader)
    {
      return myPersistance.Load(reader);
    }
  }
}