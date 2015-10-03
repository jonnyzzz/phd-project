using System;
using System.Drawing;
using System.Linq;
using DSIS.Graph.Tarjan;
using DSIS.Utils;

namespace DSIS.Graph.Images
{
  internal class ComplexBuilder : GraphFromPictureBuilderBase<ComplexGraphFromImageBuilderParameters>
  {
    public ComplexBuilder(Bitmap image, ComplexGraphFromImageBuilderParameters parameters)
      : base(image, parameters)
    {
    }

    protected override void ProcessNode<R, Q>(Coord p, R system, TarjanGraph<Q> graph)
    {
      Func<Coord, double> Hash = pp => myHash(myImage.GetPixel(pp.X, pp.Y));
      
      var node = graph.AddNode(system.Create(p.X, p.Y));
      var hash = Hash(p);
      var arcs = Neighbours(p).ToArray();

      for (int i = 0; i < myParameters.NumberOfEdgesPerPixel; i++)
      {
        var arc = arcs.Minimize(_ => Math.Abs(hash - Hash(_)));
        if (Math.Abs(hash - Hash(arc)) > myParameters.Threasold) break;

        arcs = arcs.Where(_ => _ != arc).ToArray();

        graph.AddEdgeToNode(node, graph.AddNode(system.Create(arc.X, arc.Y)));
      }
    }
  }
}