using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.Attributed;
using DSIS.Scheme2.Nodes;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class ObjectNodeFactory : Registrar<ISchemeNodeFactoryExtension, SchemeNodeFactory>,
                                   ISchemeNodeFactoryExtension
  {
    private readonly InputObjectConnectionPointFactory myObjectConnectionPointInputFactory;
    private readonly OutputObjectConnectionPointFactory myObjectConnectionPointOutputFactory;

    public ObjectNodeFactory(SchemeNodeFactory factory, InputObjectConnectionPointFactory objectConnectionPointInputFactory, OutputObjectConnectionPointFactory objectConnectionPointOutputFactory)
      : base(factory)
    {
      myObjectConnectionPointInputFactory = objectConnectionPointInputFactory;
      myObjectConnectionPointOutputFactory = objectConnectionPointOutputFactory;
    }

    public INode Create(XsdAction _action)
    {
      XsdComputationSchemeCode action = _action as XsdComputationSchemeCode;
      if (action == null)
        return null;

      Assembly assembly = Assembly.Load(action.Assembly);
      if (assembly == null)
        throw new ObjectNodeFactoryException("Failed to load assembly " + action.Assembly);

      Type tAction = assembly.GetType(action.Class);
      if (tAction == null)
        throw new ObjectNodeFactoryException("Failed to find Type " + action.Class);

      object instance = Activator.CreateInstance(tAction);

      List<IInputConnectionPoint> inputPoints = new List<IInputConnectionPoint>();
      List<IOutputConnectionPoint> outputPoints = new List<IOutputConnectionPoint>();

      foreach (MemberInfo info in tAction.GetMembers())
      {
        Add<InputAttribute, IInputConnectionPoint>(instance, info, myObjectConnectionPointInputFactory.Input, inputPoints);
        Add<OutputAttribute, IOutputConnectionPoint>(instance, info, myObjectConnectionPointOutputFactory.Output, outputPoints);
      }

      return new ObjectNode(inputPoints, outputPoints, action.Id ?? tAction.FullName, instance);
    }

    private delegate TPoint Factory<TPoint>(string name, object instance, MemberInfo info);

    private static void Add<TAttr, TPoint>(object instance, MemberInfo info, Factory<TPoint> factory,
                                           ICollection<TPoint> list)
      where TAttr : ConnectionPointAttribute
      where TPoint : class
    {
      TAttr output = GetAtttribute<TAttr>(info);
      if (output != null)
      {
        TPoint @out = factory(output.Name, instance, info);
        if (@out != null)
          list.Add(@out);
      }
    }

    private static T GetAtttribute<T>(ICustomAttributeProvider prov)
      where T : Attribute
    {
      object[] attributes = prov.GetCustomAttributes(typeof (T), true);
      if (attributes != null && attributes.Length == 1)
        return (T) attributes[0];
      return null;
    }
  }
}