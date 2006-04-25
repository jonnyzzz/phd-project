using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
  public abstract class PointMethodDefinedActionBase : UnsimmetricDefinedActionBase, IPointMethodParameters
  {
    public PointMethodDefinedActionBase(IMethodParameters methodParameters) : base(methodParameters)
    {
    }

    public override IAction Action
    {
      get { return new CPointMethodActionClass(); }
    }

    public int GetPoints(int index)
    {
      return GlobalParameters.NumberOfPoints(index);
    }

    public abstract bool UseOffsets();

    public abstract void GetOffset(int index, out double offset1, out double offset2);
  }
}