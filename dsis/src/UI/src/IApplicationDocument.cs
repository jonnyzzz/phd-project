using DSIS.Core.System;
using DSIS.Scheme.Ctx;

namespace DSIS.UI.UI
{
  public interface IApplicationDocument
  {
    string Title { get; }
    ISystemInfo System { get; }
    ISystemSpace Space { get; }

    Context Content { get;}
  }
}