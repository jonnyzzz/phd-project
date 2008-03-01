using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme.Attributed;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.XmlModel
{
  public class CurrentAppDomainFactory : ISchemeNodeFactoryExtension
  {
    private readonly IConnectionPointFactory myConnectionPointFactory;

    public CurrentAppDomainFactory(IConnectionPointFactory connectionPointFactory)
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

      ConnectionPointInfo input = new ConnectionPointInfo(myConnectionPointFactory, typeof(InputAttribute), instance);
      ConnectionPointInfo output = new ConnectionPointInfo(myConnectionPointFactory, typeof(OutputAttribute), instance);
      
      ConnectionPointInfo[] points = new ConnectionPointInfo[] { input, output, };

      foreach (PropertyInfo info in tAction.GetProperties())
      {
        foreach (ConnectionPointInfo point in points)
        {
          point.Match(info);
        }        
      }

      foreach (FieldInfo info in tAction.GetFields())
      {
        foreach (ConnectionPointInfo point in points)
        {
          point.Match(info);
        }                
      }

      return new AppDomainNode(input.Points, output.Points, tAction.FullName);
    }


    private class ConnectionPointInfo
    {
      private readonly object myInstance;
      private readonly IConnectionPointFactory myFactory;
      private readonly List<IConnectionPoint> myPoints = new List<IConnectionPoint>();
      private readonly Type myAttributeToCheck;

      public ConnectionPointInfo(IConnectionPointFactory factory, Type attributeToCheck, object instance)
      {
        myFactory = factory;
        myInstance = instance;
        myAttributeToCheck = attributeToCheck;
      }

      public void Match(PropertyInfo property)
      {
        if (Check(property))
        {
          myPoints.Add(myFactory.ForProperty(myInstance, property));
        }                
      }

      private bool Check(ICustomAttributeProvider property)
      {
        return property.IsDefined(myAttributeToCheck, true);
      }

      public void Match(FieldInfo field)
      {
        if (Check(field))
        {
          myPoints.Add(myFactory.ForField(myInstance, field));
        }                
      }

      public List<IConnectionPoint> Points
      {
        get { return myPoints; }
      }
    }
  }
}