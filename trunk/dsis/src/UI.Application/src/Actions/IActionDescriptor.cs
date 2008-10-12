using DSIS.Core.Ioc;

namespace DSIS.UI.Application.Actions
{
  public interface IActionDescriptor
  {
    string ParentId { get; }
    string ActionId { get; }
    string Ancor { get; }
  }
}