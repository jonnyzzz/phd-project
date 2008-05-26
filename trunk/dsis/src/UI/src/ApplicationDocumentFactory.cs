using DSIS.Core.System;
using DSIS.Spring.Attributes;

namespace DSIS.UI.UI
{
  [SpringBean]
  public class ApplicationDocumentFactory : IApplicationDocumentFactory
  {
    public string Title { get; set;}

    public ISystemInfo Info { get; set;}

    public ISystemSpace Space { get; set;}

    public IApplicationDocument CreateDocument()
    {
      return new ApplicationDocument(Title, Info, Space);
    }
  }
}