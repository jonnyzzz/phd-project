using System;
using System.Collections.Generic;

namespace DSIS.UI.Application.Doc.Actions
{
  public interface IDocumentActionManager
  {
    event EventHandler<EventArgs> ActionAvailabilityChanged;
    IEnumerable<IDocumentActionEx> GetActions();

    IDisposable DisableActions();
    void UpdateActionAvailability();
  }
}