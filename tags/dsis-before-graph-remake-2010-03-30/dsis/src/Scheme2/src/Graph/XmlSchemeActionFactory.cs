using DSIS.Core.Ioc;
using DSIS.Scheme2.Nodes;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Graph
{
  [UsedBySpring]
  public class XmlSchemeActionFactory :// Registrar<ISchemeNodeFactoryExtension, SchemeNodeFactory>,
                                        ISchemeNodeFactoryExtension
  {
    private readonly SchemeGraphFactory myFactory;

    public XmlSchemeActionFactory(SchemeNodeFactory factory, SchemeGraphFactory schemaFactory) //: base(factory)
    {
      myFactory = schemaFactory;
    }

    public INode Create(XsdAction action)
    {
      var scheme = action as XsdComputationScheme;
      if (scheme == null)
        return null;

      return myFactory.Build(scheme);
    }
  }
}