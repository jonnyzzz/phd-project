using System.Collections.Generic;

namespace DSIS.Scheme2.XmlModel
{
  public class AppDomainNode : INode
  {
    private readonly ICollection<IConnectionPoint> myInput;
    private readonly ICollection<IConnectionPoint> myOutput;
    private readonly string myName;

    public AppDomainNode(ICollection<IConnectionPoint> input, ICollection<IConnectionPoint> output, string name)
    {
      myInput = input;
      myName = name;
      myOutput = output;
    }

    public ICollection<IConnectionPoint> Input
    {
      get { return myInput; }
    }

    public ICollection<IConnectionPoint> Output
    {
      get { return myOutput; }
    }

    public string Name
    {
      get { return myName; }
    }
  }
}