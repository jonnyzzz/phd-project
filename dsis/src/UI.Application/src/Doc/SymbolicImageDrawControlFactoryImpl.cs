using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Graph;
using DSIS.UI.UI;

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