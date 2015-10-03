using System.Collections.Generic;
using DSIS.Scheme2.ConnectionPoints;
using DSIS.Scheme2.ConnectionPoints.Xml.Input;
using DSIS.Scheme2.ConnectionPoints.Xml.Output;
using DSIS.Scheme2.Nodes;
using DSIS.Scheme2.XmlModel;
using DSIS.Utils;
using log4net;

namespace DSIS.Scheme2.Graph
{
  public class SchemeGraph : NodeBase, ISchemeGraphBuildContext
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (SchemeGraph));

    private readonly Dictionary<string, INode> myActions = new Dictionary<string, INode>();
    private readonly SchemeNodeFactory myFactory;
    private readonly OutputConnectionPointFactory myOutputConnection;
    private readonly InputConnectionPointFactory myInputConnection;
    private readonly List<IInitializeAware> myInitializers = new List<IInitializeAware>();
    private readonly Dictionary<string, object> myUserDataHolder = new Dictionary<string, object>();


    public SchemeGraph(XsdComputationScheme scheme, SchemeNodeFactory factory,
                       OutputConnectionPointFactory outputConnection, InputConnectionPointFactory inputConnection)
      : base(new List<IInputConnectionPoint>(), new List<IOutputConnectionPoint>(), scheme.Id)
    {
      myFactory = factory;
      myInputConnection = inputConnection;
      myOutputConnection = outputConnection;

      BuildActions(scheme);
      ExternalPoints(scheme);
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

      foreach (XsdConnectionsArc arc in Safe(scheme.Connections.Arc))
      {
        IInputConnectionPoint input = myInputConnection.Create(this, arc.To);
        IOutputConnectionPoint output = myOutputConnection.Create(this, arc.From);

        RegisterInitializeAware(output as IInitializeAware);
        RegisterInitializeAware(input as IInitializeAware);

        if (output == null)
          throw new SchemeGraphException("Failed to deserialize 'from' action");
        if (input == null)
          throw new SchemeGraphException("Failed to deserialize 'to' action");

        input.Bind(output);
      }
    }

    private void ExternalPoints(XsdComputationScheme external)
    {
      ExternalPointInput(external.External);
      ExternalPointOutput(external.External);
    }

    private void ExternalPointInput(XsdComputationSchemeExternal inputs)
    {
      if (inputs == null)
        return;

      foreach (XsdEdgePoint input in Safe(inputs.Inputs))
      {
        Input.Add(GetAction(input.Id).GetInput(input.Point));
      }
    }

    private void ExternalPointOutput(XsdComputationSchemeExternal outputs)
    {
      if (outputs == null)
        return;

      foreach (XsdEdgePoint point in Safe(outputs.Outputs))
      {
        Output.Add(GetAction(point.Id).GetOutput(point.Point));
      }
    }

    public void Start()
    {
      foreach (IInitializeAware node in myInitializers)
      {
        node.Initialized();
      }
    }


    public override void Initialized()
    {
      base.Initialized();
      Start();
    }

    private static T[] Safe<T>(T[] array)
    {
      return array ?? EmptyArray<T>.Instance;
    }

    INode ISchemeGraphBuildContext.GetAction(string name)
    {
      return GetAction(name);
    }

    private INode GetAction(string name)
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