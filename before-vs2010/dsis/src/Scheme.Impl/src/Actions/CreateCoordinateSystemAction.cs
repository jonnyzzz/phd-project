using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;

namespace DSIS.Scheme.Impl.Actions
{
  public class CreateCoordinateSystemAction : CreateCoordinateSystemActionBase
  {
    protected override IIntegerCoordinateSystem CreateSystem(ISystemSpace info)
    {
      var factoryEx = new GeneratedIntegerCoordinateFactory(GeneratedIntegerCoordinateSystemManager.Instance);
      return factoryEx.Create(info, info.InitialSubdivision);
    }
  }
}