using System.Collections.Generic;

namespace DSIS.UI.Application.Doc.Actions
{
  public interface IDocumentActionManager
  {
    IEnumerable<IDocumentActionEx> GetActions();
  }
}