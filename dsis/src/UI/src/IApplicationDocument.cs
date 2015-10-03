using DSIS.Core.System;

namespace DSIS.UI.UI
{
  public interface IApplicationDocument
  {
    string Title { get; }
    ISystemInfo System { get; }
    ISystemSpace Space { get; }
  }
}