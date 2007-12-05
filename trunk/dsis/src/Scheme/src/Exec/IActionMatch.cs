using System.Xml;

namespace DSIS.Scheme.Impl.Exec
{
  public interface IActionMatch
  {
    IAction Mactch(XmlElement element);
  }
}