using System;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Nodes
{
  public class SchemeNodeFactory //: AbstractRegistry<ISchemeNodeFactoryExtension>
  {
    public INode LoadNode(XsdAction action)
    {
      throw new NotImplementedException();
//      return ForEach<INode>(delegate(ISchemeNodeFactoryExtension instance) { return instance.Create(action); });
    }
  }
}