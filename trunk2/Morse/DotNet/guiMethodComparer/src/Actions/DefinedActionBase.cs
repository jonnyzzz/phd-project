using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
  public abstract class DefinedActionBase : IDefinedAction, IParameters
  {
    private IMethodParameters methodParameters;

    public DefinedActionBase(IMethodParameters methodParameters)
    {
      this.methodParameters = methodParameters;
    }

    public IFunction GetFunction()
    {
      return GlobalParameters.GetSystemFunction().IFunction;
    }

    public abstract string Name { get; }

    public abstract IAction Action { get; }

    public virtual IParameters GetParameters(ResultSet forSet)
    {
      return this;
    }

    public virtual int GetFactor(int index)
    {
      return GlobalParameters.Subdivision(index);
    }

    protected IMethodParameters GlobalParameters
    {
      get { return methodParameters; }
    }
  }
  
  public abstract class UnsimmetricDefinedActionBase : DefinedActionBase, IUnsimmetricDefinedAction
  {
    private int myUnsimmetrisSteps;
    private int myUnsimmetricStep;
    private bool myUseUnsimmetric;

    public UnsimmetricDefinedActionBase(IMethodParameters methodParameters) : base(methodParameters)
    {
      myUnsimmetrisSteps = methodParameters.Dimension;
      myUnsimmetricStep = 0;
      myUseUnsimmetric = false;
    }

    public override int GetFactor(int index)
    {
      if (!myUseUnsimmetric) 
        return base.GetFactor(index);
      else
        return index == myUnsimmetricStep ? base.GetFactor(index) : 1;
    }


    public bool UseUnsimmetric
    {
      get { return myUseUnsimmetric; }
      set { myUseUnsimmetric = value; }
    }

    public int UnsimmetricStep
    {
      get { return myUnsimmetricStep; }
      set { myUnsimmetricStep = value; }
    }

    public int UnsimmetrisSteps
    {
      get { return myUnsimmetrisSteps; }
    }
  }
}