using DSIS.Core.System;

namespace DSIS.UI.UI
{
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