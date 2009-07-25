using System;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner
{
  public class BuilderData : IEquatable<BuilderData>, ICloneable<BuilderData>
  {
    public SystemInfoAction system { get; set; }
    public int repeat { get; set; }

    public TimeSpan ExecutionTimeout { get; set; }
    public long MemoryLimit { get; set; }

    public CoordinateSystemType CoordinateSystemType { get; set; }

    public BuilderData()
    {
      ExecutionTimeout = TimeSpan.MaxValue;
      var K = 1024;
      var M = K*1024L;
      MemoryLimit = 2 * 1024 * M;
      CoordinateSystemType = CoordinateSystemType.Generated;
    }

    protected BuilderData(BuilderData data)
    {
      system = data.system;
      repeat = data.repeat;
      ExecutionTimeout = data.ExecutionTimeout;
      MemoryLimit = data.MemoryLimit;
    }

    public bool Equals(BuilderData other)
    {
      return other.system == system;
    }

    public override bool Equals(object obj)
    {
      return obj is BuilderData ? Equals((BuilderData)obj) : false;
    }

    public override int GetHashCode()
    {
      return system.GetHashCode();
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
      log.Write("Timeout: {0}", ExecutionTimeout);
      log.Write("Coodinate System: {0}", CoordinateSystemType);
    }
  }
}