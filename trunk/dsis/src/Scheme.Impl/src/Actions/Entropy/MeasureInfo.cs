using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureInfo<Q> where Q : ICellCoordinate
  {
    public readonly int Proj;
    public readonly int Step;
    public readonly IGraphMeasure<Q> Measure;

    public MeasureInfo(int step, int proj, IGraphMeasure<Q> measure)
    {
      Step = step;
      Proj = proj;
      Measure = measure;
    }

    public static double Rho(MeasureInfo<Q> m1, MeasureInfo<Q> m2)
    {      
      var vect = new Vector<NodePair<Q>>();

      foreach (var m in m1.Measure.Measure)
      {
        vect.Add(new NodePair<Q>(m.First.From, m.First.To), m.Second);
      }
      foreach (var m in m2.Measure.Measure)
      {
        vect.Add(new NodePair<Q>(m.First.From, m.First.To), -m.Second);
      }

      double v = 0;
      foreach (var pair in vect.Dictionary)
      {
        v += Math.Abs(pair.Value);        
      }
      return v;
    }

    public override string ToString()
    {
      return "step=" + Step + " proj=" + Proj;
      ;
    }
  }
}