using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Scheme.XmlModel
{
  public class SchemeNodeFactory
  {
    private readonly ICollection<ISchemeNodeFactoryExtension> myFactories;

    public SchemeNodeFactory(ICollection<ISchemeNodeFactoryExtension> factories)
    {
      myFactories = factories;
    }

    public INode LoadNode(XsdAction action)
    {
      foreach (ISchemeNodeFactoryExtension factory in myFactories)
      {
        INode node = factory.Create(action);
        if (node != null)
          return node;
      }
      return null;
    }
  }
}