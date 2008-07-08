using DSIS.Core.Coordinates;
using DSIS.Persistance;
using DSIS.Spring.Attributes;

namespace DSIS.IntegerCoordinates.Generated
{
  [SpringBean]
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