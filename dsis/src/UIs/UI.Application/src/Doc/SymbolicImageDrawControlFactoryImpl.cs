using System.Collections.Generic;
using DSIS.Graph;
using DSIS.UI.UI;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Doc
{
  [ComponentImplementation]
  public class SymbolicImageDrawControlFactoryImpl : ISymbolicImageDrawControlFactory
  {
    [Autowire]
    private ITypeInstantiator Instantiator { get; set; }

    public ISymbolicImageDrawControl Create(IGraphStrongComponents components, IEnumerable<IStrongComponentInfo> info)
    {
      return Instantiator.Instanciate<StandaloneImageDrawWithIcCHelper>(components, info);
    }
  }
}