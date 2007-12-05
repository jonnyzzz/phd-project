using System.Xml;

namespace DSIS.Scheme.Exec
{
  public interface IActionMatch
  {
    IAction Mactch(XmlElement element);
  }
}