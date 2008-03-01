using System.Collections.Generic;

namespace DSIS.Scheme2.XmlModel
{
  public class AppDomainNode : INode
  {
    private readonly ICollection<IInputConnectionPoint> myInput;
    private readonly ICollection<IOutputConnectionPoint> myOutput;
    private readonly string myName;

    public AppDomainNode(ICollection<IInputConnectionPoint> input, ICollection<IOutputConnectionPoint> output, string name)
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

    public string Name
    {
      get { return myName; }
    }
  }
}