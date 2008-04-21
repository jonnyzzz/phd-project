using System.Xml;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Exec
{
  public class SimpleActionMatch<C> : IActionMatch
    where C : class, IAction, new()
  {
    private readonly string myName;

    public SimpleActionMatch(string name)
    {
      myName = name;
    }

    public IAction Mactch(XmlElement element)
    {
      if (element.Name == myName)
        return new C();
      return null;
    }
  }
}