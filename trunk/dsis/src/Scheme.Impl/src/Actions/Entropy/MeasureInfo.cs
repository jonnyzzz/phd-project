using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureInfo<Q> : IMeasureInfo<Q>
    where Q : ICellCoordinate
  {
    private readonly List<IGraphMeasure<Q>> myMeasures; 
    
    public int Proj { get; private set; }
    public int Step { get; private set;}

    public IEnumerable<IGraphMeasure<Q>> Measures2()
    {
      return myMeasures; 
    }

    public IEnumerable<IGraphMeasure> Measures()
    {
      foreach (var mes in myMeasures)
      {
        yield return mes;
      }
    }

    public double Dist(IMeasureInfo _info)
    {
      return Rho(this, (MeasureInfo<Q>) _info);
    }


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

    public void Join<T>(IGraphMeasure<T> mes) where T : ICellCoordinate
    {
      Join((IGraphMeasure<Q>)mes);
    }

    public void DoGeneric(IMeasureInfoWith with)
    {
      with.With(this);
    }

    private void Join(IGraphMeasure<Q> mes)
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