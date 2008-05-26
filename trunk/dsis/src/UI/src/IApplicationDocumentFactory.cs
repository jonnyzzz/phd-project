using DSIS.Core.System;

namespace DSIS.UI.UI
{
  public interface IApplicationDocumentFactory
  {
    string Title { get; set; }
    ISystemInfo Info { get; set; }
    ISystemSpace Space { get; set; }

    /// <summary>
    /// Creates instance of the document based on the properties that are set
    /// </summary>
    /// <returns></returns>
    IApplicationDocument CreateDocument();
  }
}