using System.Collections.Generic;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.XmlModel
{
  public class SchemeGraph
  {
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
      foreach (XsdAction action in scheme.Actions)
      {
        INode node = myFactory.LoadNode(action);
        if (node != null)
        {
          myActions[node.Name] = node;
        }
      }
    }

    private void LinkActions(XsdComputationScheme scheme)
    {
      foreach (XsdArc arc in scheme.Connections.Arc)
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
  }
}