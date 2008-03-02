using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.XmlModel
{
  public class SchemeNodeFactory : AbstractRegistry<ISchemeNodeFactoryExtension>
  {    
    public INode LoadNode(XsdAction action)
    {
      return ForEach<INode>(delegate(ISchemeNodeFactoryExtension instance) { return instance.Create(action); });      
    }
  }
}