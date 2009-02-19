using System;
using DSIS.Scheme;

namespace DSIS.SimpleRunner
{
  public struct ComputationData : IEquatable<ComputationData>
  {
    public IAction system { get; set; }
    public int repeat { get; set; }
    public ComputationDataBuilder builder { get; set; }

    public ComputationData Clone()
    {
      return new ComputationData
               {
                 system = system,
                 repeat = repeat,
                 builder = builder
               };
    }

    public bool Equals(ComputationData obj)
    {
      return Equals(obj.system, system) && Equals(obj.builder, builder);
    }

    public override bool Equals(object obj)
    {
      if (obj.GetType() != typeof (ComputationData)) return false;
      return Equals((ComputationData) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        int result = (system != null ? system.GetHashCode() : 0);
        result = (result*397) ^ builder.GetHashCode();
        return result;
      }
    }

    public static bool operator ==(ComputationData left, ComputationData right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(ComputationData left, ComputationData right)
    {
      return !left.Equals(right);
    }
  }
}