using System.Drawing;
using System.Linq;
using DSIS.Graph.Tarjan;

namespace DSIS.Graph.Images
{
  internal class FullBuilder : GraphFromPictureBuilderBase<FullGraphFromImageBuilderParameters>
  {
    public FullBuilder(Bitmap image, FullGraphFromImageBuilderParameters parameters)
      : base(image, parameters)
    {
    }

    protected override void ProcessNode<R, Q>(Coord p, R system, TarjanGraph<Q> graph)
    {
      var node = graph.AddNode(system.Create(p.X, p.Y));

      var neighbours = Neighbours(p).ToArray();
      foreach (var arc in neighbours)
      {
        var toNode = graph.AddNode(system.Create(arc.X, arc.Y));
        graph.AddEdgeToNode(node, toNode);
      }
    }
  }
}