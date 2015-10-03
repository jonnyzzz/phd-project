using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public abstract class MeasureInfoBase<Q> : IMeasureInfo<Q> where Q : ICellCoordinate
  {
    public int Proj { get; private set; }
    public int Step { get; private set; }

    public abstract IEnumerable<IGraphMeasure<Q>> Measures2();

    protected MeasureInfoBase(int proj, int step)
    {
      Proj = proj;
      Step = step;
    }

    public IEnumerable<IGraphMeasure> Measures()
    {
      foreach (var mes in Measures2())
      {
        yield return mes;
      }
    }

    public double Dist(IMeasureInfo _info)
    {
      return Rho(
        (CollectionUtil.And(Measures2().Map(x=>x.Measure))), 
        (CollectionUtil.And(((IMeasureInfo<Q>) _info).Measures2().Map(x=>x.Measure)))
        );
    }
    
    public void Join<T>(IGraphMeasure<T> mes) where T : ICellCoordinate
    {
      foreach (var measure in Measures2())
      {
        if (!measure.CoordinateSystem.Equals(mes.CoordinateSystem))
          throw new ArgumentException("Measure object was created against different coordinate system");
      }
      JoinInternal((IGraphMeasure<Q>) mes);
    }

    protected abstract void JoinInternal(IGraphMeasure<Q> mes);

    public void DoGeneric(IMeasureInfoWith with)
    {
      with.With(this);
    }

    public override string ToString()
    {
      return "step=" + Step + " proj=" + Proj;
    }

    private static double Rho<P>(IEnumerable<Pair<P,double>> m1, IEnumerable<Pair<P, double>> m2)
      where P : PairBase<Q>
    {
      var vect = new Vector<NodePair<Q>>();

      AddNormed(1, m1, vect);
      AddNormed(-1, m2, vect);
      return vect.Dictionary.FoldLeft(0.0, (x,vv)=>x.Value+vv);
    }

    private static void AddNormed<P>(double factor, IEnumerable<Pair<P, double>> m1, Vector<NodePair<Q>> vect)
      where P : PairBase<Q>
    {
      double m1Norm = m1.FoldLeft(0.0, (x, vv) => x.Second + vv);
      foreach (var m in m1)
      {
        vect.Add(new NodePair<Q>(m.First.From, m.First.To), factor * m.Second / m1Norm);
      }
    }
  }
}