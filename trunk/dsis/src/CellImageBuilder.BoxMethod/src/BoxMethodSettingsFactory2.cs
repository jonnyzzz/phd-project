using System;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.CellImageBuilder.BoxMethod
{
  [CellImageBuilderComponent]
  public class BoxMethodSettingsFactory2 : ICellImageBuilderFactory
  {
    public Type OptionsObjectType
    {
      get { return typeof (BoxMethodSettings); }
    }

    public string FactoryName
    {
      get { return "Box Method"; }
    }

    public ICellImageBuilder<Q> CreateSystem<Q>(ICellImageBuilderSettings settings) where Q : ICellCoordinate
    {
      return null;
//      return ((BoxMethodSettings) settings).Create<Q>();
    }
  }
}