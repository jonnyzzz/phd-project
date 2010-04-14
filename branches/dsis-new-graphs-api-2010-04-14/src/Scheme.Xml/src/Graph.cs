using DSIS.Utils;

namespace DSIS.Scheme.Xml
{
  public partial class Graph
  {
    public Hashset<string> GraphRequirements()
    {
      var req = new Hashset<string>();
      foreach (var node in nodesField.Node)
      {
        foreach (var arg in node.Args.Safe())
        {
          var gr = arg as NodeConstructorArgumentGraphReference;
          if (gr != null)
          {
            req.Add(gr.refid);
          }
        }
      }
      return req;
    }
  }
}