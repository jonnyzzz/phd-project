using System;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner.Data
{
  public class BuilderDataBase : IEquatable<BuilderDataBase>, ICloneable<BuilderDataBase>
  {
    public TimeSpan ExecutionTimeout { get; set; }
    public long MemoryLimit { get; set; }

    public BuilderDataBase()
    {
      ExecutionTimeout = TimeSpan.MaxValue;
      var K = 1024;
      var M = K*1024L;
      MemoryLimit = 5 * 1024 * M / 2;      
    }

    protected virtual void CopyState(BuilderDataBase data)
    {
      ExecutionTimeout = data.ExecutionTimeout;
      MemoryLimit = data.MemoryLimit;
    }

    public virtual void Serialize(Logger log)
    {
      log.Write("Timeout: {0}", ExecutionTimeout);
    }

    public bool Equals(BuilderDataBase other)
    {
      return other.GetType() == GetType();
    }

    BuilderDataBase ICloneable<BuilderDataBase>.Clone()
    {
      var builderDataBase = new BuilderDataBase();
      CopyState(this);
      return builderDataBase;
    }
  }

  public class BuilderData : BuilderDataBase, IEquatable<BuilderData>, ICloneable<BuilderData>
  {
    public SystemInfoAction system { get; set; }
    public int repeat { get; set; }


    public CoordinateSystemType CoordinateSystemType { get; set; }

    public BuilderData()
    {
      CoordinateSystemType = CoordinateSystemType.Generated;
    }

    protected BuilderData(BuilderData data)
    {
      CopyState(data);
    }

    protected void CopyState(BuilderData data)
    {
      base.CopyState(data);
      system = data.system;
      repeat = data.repeat;
    }

    public bool Equals(BuilderData other)
    {
      return other.system == system;
    }

    public override bool Equals(object obj)
    {
      return obj is BuilderData && Equals((BuilderData)obj);
    }

    public override int GetHashCode()
    {
      return system.GetHashCode();
    }

    BuilderData ICloneable<BuilderData>.Clone()
    {
      return new BuilderData(this);
    }

    public override void Serialize(Logger log)
    {
      log.Write("System function: {0}", system.SystemInfo.PresentableName);
      log.Write("System space: {0}", system.SystemSpace);
      log.Write("Repeat: {0}", repeat);
      base.Serialize(log);
      log.Write("Coodinate System: {0}", CoordinateSystemType);
    }
  }
}