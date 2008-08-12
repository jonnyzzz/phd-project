using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;

namespace DSIS.Scheme.Impl.Actions
{
  public class CreateCoordinateSystemAction : CreateCoordinateSystemActionBase
  {
    protected override IIntegerCoordinateSystem CreateSystem(ISystemSpace info)
    {
      IIntegerCoordinateFactoryEx factoryEx = GeneratedIntegerCoordinateSystemManager.Instance.CreateSystem(info.Dimension);
      return factoryEx.Create(info, info.InitialSubdivision);
    }
  }
}