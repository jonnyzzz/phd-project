using System;
using System.Collections.Generic;
using System.Xml;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Exec
{
  public class XmlActionGraphParser
  {
    private readonly ICollection<IActionMatch> myMatches;

    public XmlActionGraphParser()
    {
      myMatches = new IActionMatch[]
        {
          /*new SimpleActionMatch<BuildSymbolicImageAction>("build"),
          new SimpleActionMatch<ChainRecurrenctSimbolicImageAction>("chain-recurrent-set"),
          new SimpleActionMatch<CreateCoordinateSystemAction>("create"),
          new SimpleActionMatch<CreateInitialCellsAction>("initial-cells"),
          new SimpleActionMatch<MergeComponetsAction>("merge"),          */
        };
    }

    public void Parse(XmlDocument doc, IActionGraphBuilder bld)
    {
      StartAction a = new StartAction();
      foreach (XmlElement node in doc.SelectNodes("*"))
      {
        Parse(node, bld, a);
      }
    }

    private void Parse(XmlElement elem, IActionGraphBuilder bld, IAction prev)
    {
      IAction c = Parse(elem);
      bld.AddEdge(prev,c);
      foreach (XmlElement node in elem.SelectNodes("*"))
      {
        Parse(node, bld, c);
      }
    }

    private IAction Parse(XmlElement elem)
    {
      foreach (IActionMatch match in myMatches)
      {
        IAction act = match.Mactch(elem);
        if (elem != null)
          return act;        
      }
      throw new ArgumentException("Action " + elem.Name + " was not found");
    }
  }
}