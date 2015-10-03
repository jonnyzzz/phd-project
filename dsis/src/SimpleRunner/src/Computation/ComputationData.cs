using System;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.SimpleRunner.Data;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Computation
{
  public class ComputationData : BuilderData, IEquatable<ComputationData>, ICloneable<ComputationData>
  {
    public ComputationDataBuilder builder { get; set; }

    public ComputationData()
    {
    }

    protected ComputationData(ComputationData data) : base(data)
    {
      builder = data.builder;
    }

    ComputationData ICloneable<ComputationData>.Clone()
    {
      return new ComputationData(this);
    }

    public bool Equals(ComputationData obj)
    {
      return Equals((BuilderData)obj);
    }

    public override void Serialize(Logger log)
    {
      base.Serialize(log);
      log.Write("Builder: {0}", builder);
    }
  }
}