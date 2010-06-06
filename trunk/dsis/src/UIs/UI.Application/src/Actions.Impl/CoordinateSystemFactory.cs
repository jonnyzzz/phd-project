using DSIS.IntegerCoordinates.Generated;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Actions.Impl
{
  [ComponentImplementation]
  public class CoordinateSystemFactory : IDocumentContextFill
  {
    private readonly GeneratedIntegerCoordinateFactory myFactory;

    public CoordinateSystemFactory(GeneratedIntegerCoordinateFactory factory)
    {
      myFactory = factory;
    }

    public string Order
    {
      get { return "00000"; }
    }

    public void FillContext(IReadOnlyContext info, IWriteOnlyContext context)
    {
      var systemInfo = Keys.SystemSpaceKey.Get(info);
      var sys = myFactory.Create(systemInfo, systemInfo.InitialSubdivision);
      Keys.IntegerCoordinateSystemInfo.Set(context, sys);
    }
  }
}