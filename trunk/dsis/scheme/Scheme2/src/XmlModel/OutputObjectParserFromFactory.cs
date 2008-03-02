using System;
using System.Reflection;
using DSIS.Scheme2.Impl.ConnectionPoints;
using DSIS.Scheme2.Impl.ObjectParsers;
using DSIS.Spring;

namespace DSIS.Scheme2.XmlModel
{
  [UsedBySpring]
  public class OutputObjectParserFromFactory : Registrar<IOutputConnectionPointExtension, OutputConnectionPointFactory>, IOutputConnectionPointExtension
  {
    public OutputObjectParserFromFactory(OutputConnectionPointFactory factory) : base(factory)
    {
    }

    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      if (arc.Item is XsdFromObject)
      {
        XsdFromObject from = (XsdFromObject)arc.Item;
        Assembly assembly = Assembly.Load(from.FormatterAssembly);
        Type type = assembly.GetType(from.FormatterClass);

        IObjectParser factory = (IObjectParser) Activator.CreateInstance(type);
        object o = factory.Parse(from.Any);

        return ActionOutputConnectionPoint.FromActionObject(from.Name, o);
      }
      return null;
    }
  }
}