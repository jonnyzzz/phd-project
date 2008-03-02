using System.Collections.Generic;
using DSIS.Scheme2.Impl.ConnectionPoints;

namespace DSIS.Scheme2.XmlModel
{
  public class AppDomainNode : NodeBase, INodeAsOutputAction
  {

    private readonly object myAction;


    public AppDomainNode(ICollection<IInputConnectionPoint> input, ICollection<IOutputConnectionPoint> output, string name, object action) : base(input, output, name)
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
      return ActionOutputConnectionPoint.FromActionObject(Name, myAction);
    }
  }  
}