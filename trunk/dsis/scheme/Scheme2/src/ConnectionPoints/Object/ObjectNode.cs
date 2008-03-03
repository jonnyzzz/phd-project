using System.Collections.Generic;
using DSIS.Scheme2.Nodes;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  public class ObjectNode : NodeBase, INodeAsOutputAction
  {
    private readonly object myAction;

    public ObjectNode(ICollection<IInputConnectionPoint> input, ICollection<IOutputConnectionPoint> output, string name,
                      object action) : base(input, output, name)
    {
      myAction = action;
    }

    public override void Initialized()
    {
      IInitializeAware init = myAction as IInitializeAware;
      if (init != null)
        init.Initialized();
    }

    public IOutputConnectionPoint AsOutputConnectionPoint()
    {
      return ActionOutputConnectionPoint.FromActionObject(Name, new object[] { myAction });
    }
  }
}