using System;
using System.Collections.Generic;
using DSIS.Scheme2.XmlModel;
using DSIS.Utils;
using log4net;

namespace DSIS.Scheme2.XmlModel
{
  public class SchemeGraph : ISchemeGraphBuildContext
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (SchemeGraph));

    private readonly Dictionary<string, INode> myActions = new Dictionary<string, INode>();
    private readonly SchemeNodeFactory myFactory;
    private readonly OutputConnectionPointFactory myOutputConnection;
    private readonly List<IInitializeAware> myInitializers = new List<IInitializeAware>();
    private readonly Dictionary<string, object> myUserDataHolder = new Dictionary<string, object>();

    public SchemeGraph(XsdComputationScheme scheme, SchemeNodeFactory factory, OutputConnectionPointFactory outputConnection)
    {
      myFactory = factory;
      myOutputConnection = outputConnection;

      BuildActions(scheme);
      LinkActions(scheme);
    }

    private void BuildActions(XsdComputationScheme scheme)
    {
      foreach (XsdAction action in Safe(scheme.Actions))
      {
        INode node = myFactory.LoadNode(action);
        if (node != null)
        {
          LOG.InfoFormat("Added action {0} of type {1}", node.Name, node.GetType().FullName);
          RegisterInitializeAware(node);
          myActions[node.Name] = node;
        }
      }
    }

    private void LinkActions(XsdComputationScheme scheme)
    {
      if (scheme.Connections == null)
        return;

      foreach (XsdArc arc in Safe(scheme.Connections.Arc))
      {
        IInputConnectionPoint input = myActions[arc.To.Id].GetInput(arc.To.Point);
        IOutputConnectionPoint output = myOutputConnection.Create(this, arc);

        RegisterInitializeAware(output as IInitializeAware);
        RegisterInitializeAware(input as IInitializeAware);

        if (output == null)
          throw new SchemeGraphException("Failed to deserialize action {0}" + (arc.Item != null ? arc.Item.GetType().FullName : "null"));

        input.Bind(output);        
      }
    }

    public void Start()
    {
      foreach (IInitializeAware node in myInitializers)
      {
        node.Initialized();
      }
    }

    private static T[] Safe<T>(T[] array)
    {
      return array ?? EmptyArray<T>.Instance;
    }

    INode ISchemeGraphBuildContext.GetAction(string name)
    {
      return myActions[name];
    }

    public void RegisterInitializeAware(IInitializeAware aware)
    {
      if (aware != null)
        myInitializers.Add(aware);
    }

    public T GetUserData<T>(object host, string key, T def)
    {
      object obj;
      if (myUserDataHolder.TryGetValue(Key(host, key), out obj))
        return (T) obj;
      SetUserData(host, key, def);
      
      return def;
    }


    private static string Key(object host, string key)
    {
      return host.GetType().FullName + "|" + host.GetHashCode() + "|" + key;
    }
    
    public void SetUserData<T>(object host, string key, T data)
    {
      myUserDataHolder[Key(host, key)] = data;
    }
  }
}