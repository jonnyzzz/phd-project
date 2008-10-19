using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Actions.Impl
{
  [ComponentImplementation]
  public class ApplicationDocumentFactory : IApplicationDocumentFactory
  {
    public IApplicationDocument CreateNewDocument(string title, ISystemInfo info, ISystemSpace space)
    {
      return new ApplicationDocument(title, info, space);
    }
  }
}