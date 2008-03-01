using System.Collections.Generic;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.XmlModel
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