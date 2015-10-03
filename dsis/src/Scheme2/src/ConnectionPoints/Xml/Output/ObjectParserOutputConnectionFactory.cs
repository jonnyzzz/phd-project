using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
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
    private readonly ObjectParserFactory myParsers;

    public ObjectParserOutputConnectionFactory(OutputConnectionPointFactory factory, ObjectParserFactory parsers) : base(factory)
    {
      myParsers = parsers;
    }

    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      if (arc.Item is XsdFromObject)
      {
        XsdFromObject from = (XsdFromObject) arc.Item;

        List<object> os = new List<object>();

        foreach(XmlElement any in from.Any)
        {
          object o = myParsers.Parse(any);

          if (o == null)
          {
            Assembly assembly = Assembly.Load(from.FormatterAssembly);
            Type type = assembly.GetType(from.FormatterClass);

            IObjectParser factory = (IObjectParser) Activator.CreateInstance(type);
            o = factory.Parse(any);
          }
          if (o != null)
            os.Add(o);
        }

        if (os.Count == 0)
          return null;
        
        return ActionOutputConnectionPoint.FromActionObject(from.Name, os.ToArray());
      }
      return null;
    }
  }
}