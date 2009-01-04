using System.Collections.Generic;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class DefaultDocumentCenterControls : IDocumentCenterControlFactory
  {
    private readonly IDocumentCenterControl[] myControls;

    public DefaultDocumentCenterControls(IDocumentCenterControl[] controls)
    {
      myControls = controls;
    }

    public IEnumerable<IDocumentCenterControl> CreateDocumentCenterControls()
    {
      return myControls;
    }
  }
}