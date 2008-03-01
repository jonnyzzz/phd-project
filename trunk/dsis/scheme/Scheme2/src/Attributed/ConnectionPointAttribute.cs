using System;

namespace DSIS.Scheme.Attributed
{
  public abstract class ConnectionPointAttribute : Attribute
  {
    private readonly string myName;

    protected ConnectionPointAttribute(string name)
    {
      myName = name;
    }
  }
}