using System;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner
{
  public class ComputationData : IEquatable<ComputationData>
  {
    public SystemInfoAction system { get; set; }
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

    public void Serialize(Logger log)
    {
      log.Write("System function: {0}", system.SystemInfo);
      log.Write("System space: {0}", system.SystemSpace);
      log.Write("Repeat: {0}", repeat);
      log.Write("Builder: {0}", builder);
    }
  }
}