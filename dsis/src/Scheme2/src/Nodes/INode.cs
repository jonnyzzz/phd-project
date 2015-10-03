using System.Collections.Generic;
using DSIS.Scheme2.ConnectionPoints;

namespace DSIS.Scheme2.Nodes
{
  public interface INode : IInitializeAware
  {
    ICollection<IInputConnectionPoint> Input { get; }
    ICollection<IOutputConnectionPoint> Output { get; }

    IInputConnectionPoint GetInput(string name);
    IOutputConnectionPoint GetOutput(string name);

    string Name { get; }
  }

  public interface INodeAsOutputAction
  {
    IOutputConnectionPoint AsOutputConnectionPoint();
  }
}