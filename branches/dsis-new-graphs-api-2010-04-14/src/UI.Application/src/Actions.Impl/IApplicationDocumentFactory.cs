using DSIS.Core.System;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Actions.Impl
{
  public interface IApplicationDocumentFactory
  {
    IApplicationDocument CreateNewDocument(string title, ISystemInfo info, ISystemSpace space);
  }
}