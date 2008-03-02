using System;
using System.Reflection;
using DSIS.Scheme2.ConnectionPoints.Object;
using DSIS.Scheme2.Graph;
using DSIS.Scheme2.ObjectParsers;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Output
{
  [UsedBySpring]
  public class ObjectParserOutputConnectionFactory :
    Registrar<IOutputConnectionPointExtension, OutputConnectionPointFactory>, IOutputConnectionPointExtension
  {
    public ObjectParserOutputConnectionFactory(OutputConnectionPointFactory factory) : base(factory)
    {
    }

    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      if (arc.Item is XsdFromObject)
      {
        XsdFromObject from = (XsdFromObject) arc.Item;
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