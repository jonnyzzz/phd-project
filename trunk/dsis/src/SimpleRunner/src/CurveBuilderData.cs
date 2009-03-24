using System;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class CurveBuilderData : BuilderData, ICloneable<CurveBuilderData>, IEquatable<CurveBuilderData>
  {
    protected CurveBuilderData(BuilderData data) : base(data)
    {
    }

    public double eps { get; set; }
    public double[] Point1 { get; set; }
    public double[] Point2 { get; set; }

    public CurveBuilderData()
    {
    }
    
    public CurveBuilderData(CurveBuilderData data) : base(data)
    {
      eps = data.eps;
      Point1 = (double[]) data.Point1.Clone();
      Point2 = (double[]) data.Point2.Clone();
    }

    public override bool Equals(object obj)
    {
      return base.Equals(obj) && (obj is CurveBuilderData && Equals(((CurveBuilderData)obj)));
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public bool Equals(CurveBuilderData data)
    {
      if (Equals(((BuilderData)data)))
        return false;

      if (eps != data.eps)
        return false;

      if (Point1.JoinString("|") != data.Point1.JoinString("|"))
        return false;

      if (Point2.JoinString("|") != data.Point2.JoinString("|"))
        return false;

      return true;
    }

    public override void Serialize(Logger log)
    {
      base.Serialize(log);
      log.Write("Eps = " + eps);
      log.Write("Point1 = " + Point1.JoinString(","));
      log.Write("Point2 = " + Point2.JoinString(","));
    }

    public CurveBuilderData Clone()
    {
      throw new System.NotImplementedException();
    }
  }
}