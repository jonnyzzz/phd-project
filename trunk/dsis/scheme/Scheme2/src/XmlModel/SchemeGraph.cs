using System.Collections.Generic;
using DSIS.Scheme2.XmlModel;
using DSIS.Utils;
using log4net;

namespace DSIS.Scheme2.XmlModel
{
  public class SchemeGraph
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (SchemeGraph));

    private readonly Dictionary<string, INode> myActions = new Dictionary<string, INode>();
    private readonly SchemeNodeFactory myFactory;
    private readonly XsdComputationScheme myScheme;

    public SchemeGraph(XsdComputationScheme scheme, SchemeNodeFactory factory)
    {
      myFactory = factory;
      myScheme = scheme;

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

        if (arc.Item is XsdEdgePoint)
        {
          XsdEdgePoint from = (XsdEdgePoint)arc.Item;


          INode node = myActions[from.Id];
          IOutputConnectionPoint output = node.GetOutput(from.Point);
          input.Bind(output);
        }
      }
    }

    public void Start()
    {
      foreach (INode node in myActions.Values)
      {
        node.Initizlized();
      }
    }

    private static T[] Safe<T>(T[] array)
    {
      return array ?? EmptyArray<T>.Instance;
    }
  }
}