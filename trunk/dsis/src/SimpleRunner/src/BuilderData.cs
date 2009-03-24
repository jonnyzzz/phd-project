using System;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner
{
  public class BuilderData : IEquatable<BuilderData>, ICloneable<BuilderData>
  {
    public SystemInfoAction system { get; set; }
    public int repeat { get; set; }

    public BuilderData()
    {
    }

    protected BuilderData(BuilderData data)
    {
      system = data.system;
      repeat = data.repeat;
    }

    public bool Equals(BuilderData other)
    {
      return other.system == system && other.repeat == repeat;
    }

    public override bool Equals(object obj)
    {
      return obj is BuilderData ? Equals((BuilderData)obj) : false;
    }

    public override int GetHashCode()
    {
      return repeat*133 + system.GetHashCode();
    }

    BuilderData ICloneable<BuilderData>.Clone()
    {
      return new BuilderData(this);
    }

    public virtual void Serialize(Logger log)
    {
      log.Write("System function: {0}", system.SystemInfo);
      log.Write("System space: {0}", system.SystemSpace);
      log.Write("Repeat: {0}", repeat);
    }
  }
}