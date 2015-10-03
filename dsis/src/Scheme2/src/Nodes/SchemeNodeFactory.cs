using DSIS.Scheme2.XmlModel;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.Nodes
{
  public class SchemeNodeFactory : AbstractRegistry<ISchemeNodeFactoryExtension>
  {
    public INode LoadNode(XsdAction action)
    {
      return ForEach<INode>(delegate(ISchemeNodeFactoryExtension instance) { return instance.Create(action); });
    }
  }
}