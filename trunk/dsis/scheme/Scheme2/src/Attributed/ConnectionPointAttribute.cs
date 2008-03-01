using System;

namespace DSIS.Scheme2.Attributed
{
  public abstract class ConnectionPointAttribute : Attribute
  {
    private readonly string myName;

    protected ConnectionPointAttribute(string name)
    {
      myName = name;
    }

    public string Name
    {
      get { return myName; }
    }
  }
}