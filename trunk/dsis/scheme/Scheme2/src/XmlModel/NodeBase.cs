using System;
using System.Collections.Generic;

namespace DSIS.Scheme2.XmlModel
{
  public class NodeBase : INode
  {
    private readonly ICollection<IInputConnectionPoint> myInput;
    private readonly ICollection<IOutputConnectionPoint> myOutput;
    private readonly string myName;

    public NodeBase(ICollection<IInputConnectionPoint> input, ICollection<IOutputConnectionPoint> output, string name)
    {
      myInput = input;
      myOutput = output;
      myName = name;
    }

    public ICollection<IInputConnectionPoint> Input
    {
      get { return myInput; }
    }

    public ICollection<IOutputConnectionPoint> Output
    {
      get { return myOutput; }
    }

    public IInputConnectionPoint GetInput(string name)
    {
      foreach (IInputConnectionPoint point in myInput)
      {
        if (point.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
          return point;
      }
      return null;
    }

    public IOutputConnectionPoint GetOutput(string name)
    {
      foreach (IOutputConnectionPoint point in myOutput)
      {
        if (point.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
          return point;
      }
      return null;
    }

    public string Name
    {
      get { return myName; }
    }

    public virtual void Initialized()
    {      
    }
  }
}