using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.Attributed;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.XmlModel
{
  public class CurrentAppDomainFactory : ISchemeNodeFactoryExtension
  {
    private readonly ConnectionPointFactory myConnectionPointFactory;

    public CurrentAppDomainFactory(ConnectionPointFactory connectionPointFactory)
    {
      myConnectionPointFactory = connectionPointFactory;
    }

    public INode Create(XsdAction _action)
    {
      XsdUserAction action = _action as XsdUserAction;
      if (action == null)
        return null;

      Assembly assembly = Assembly.Load(action.Assembly);
      Type tAction = assembly.GetType(action.Class);

      object instance = Activator.CreateInstance(tAction);

      List<IInputConnectionPoint> inputPoints = new List<IInputConnectionPoint>();
      List<IOutputConnectionPoint> outputPoints = new List<IOutputConnectionPoint>();
            
      foreach (MemberInfo info in tAction.GetMembers())
      {
        Add<InputAttribute, IInputConnectionPoint>(instance, info, myConnectionPointFactory.Input, inputPoints);
        Add<OutputAttribute, IOutputConnectionPoint>(instance, info, myConnectionPointFactory.Output, outputPoints);       
      }
      
      return new AppDomainNode(inputPoints, outputPoints, tAction.FullName);
    }

    private delegate TPoint Factory<TPoint>(string name, object instance, MemberInfo info);

    private static void Add<TAttr, TPoint>(object instance, MemberInfo info, Factory<TPoint> factory, ICollection<TPoint> list)
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
      object[] attributes = prov.GetCustomAttributes(typeof(T), true);
      if (attributes != null && attributes.Length == 1)
        return (T) attributes[0];
      return null;
    }
  }
}