using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  public interface IDocumentCenterControl : IControlWithTitle
  {
    string SortOrder { get; }
  }
}