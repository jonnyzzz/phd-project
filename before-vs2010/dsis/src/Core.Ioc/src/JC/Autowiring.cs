using System;

namespace DSIS.Core.Ioc.JC
{
  public abstract class Autowiring
  {
    public Type Type { get; private set;}
    public string Name { get; private set;}

    protected Autowiring(Type type, string name)
    {
      Type = type;
      Name = name;
    }

    public void SetValue(object value)
    {
      if (!Type.IsAssignableFrom(value.GetType()))
      {
        throw new ArgumentException("Failed to set " + value.GetType() + " but expected was " + Type);
      }      
      DoSetValue(value);
    }

    protected abstract void DoSetValue(object value);
  }
}