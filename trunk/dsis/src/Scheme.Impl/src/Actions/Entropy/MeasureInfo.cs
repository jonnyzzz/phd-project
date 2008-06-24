using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureInfo<Q> where Q : ICellCoordinate
  {
    public readonly int Proj;
    public readonly int Step;
    public readonly List<IGraphMeasure<Q>> myMeasures;

    public MeasureInfo(int step, int proj, IGraphMeasure<Q> measure)
    {
      Step = step;
      Proj = proj;
      myMeasures = new List<IGraphMeasure<Q>> {measure};
    }

    public static double Rho(MeasureInfo<Q> m1, MeasureInfo<Q> m2)
    {       
      var vect = new Vector<NodePair<Q>>();

      foreach (var m1M in m1.myMeasures)
      {
        foreach (var m2M in m2.myMeasures)
        {
          if (!m1M.CoordinateSystem.Equals(m2M.CoordinateSystem))
            throw new ArgumentException("Measure object was created against different coordinate system");
        }
      }

      foreach (var measure in m1.myMeasures)
      {
        foreach (var m in measure.Measure)
        {
          vect.Add(new NodePair<Q>(m.First.From, m.First.To), m.Second);
        }
      }

      foreach (var measure in m2.myMeasures)
      {
        foreach (var m in measure.Measure)
        {
          vect.Add(new NodePair<Q>(m.First.From, m.First.To), -m.Second);
        }
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
    }

    public void Join(IGraphMeasure<Q> mes)
    {
      foreach (var measure in myMeasures)
      {
        if (!measure.CoordinateSystem.Equals(mes.CoordinateSystem))
          throw new ArgumentException("Measure object was created against different coordinate system");
      }

      myMeasures.Add(mes);
    }
  }
}