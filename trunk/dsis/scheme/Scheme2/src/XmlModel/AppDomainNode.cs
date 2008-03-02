using System;
using System.Collections.Generic;
using DSIS.Scheme2.Impl.ConnectionPoints;

namespace DSIS.Scheme2.XmlModel
{
  public class AppDomainNode : INode, INodeAsOutputAction
  {
    private readonly ICollection<IInputConnectionPoint> myInput;
    private readonly ICollection<IOutputConnectionPoint> myOutput;
    private readonly string myName;
    private readonly object myAction;

    public AppDomainNode(ICollection<IInputConnectionPoint> input, ICollection<IOutputConnectionPoint> output, string name, object action)
    {
      myInput = input;
      myAction = action;
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

    public void Initialized()
    {
      IInitializeAware init = myAction as IInitializeAware;
      if (init != null)
        init.Initialized();      
    }

    public IOutputConnectionPoint AsOutputConnectionPoint()
    {
      return ActionOutputConnectionPoint.FromActionObject(Name, myAction);
    }
  }  
}