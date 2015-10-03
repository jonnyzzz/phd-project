using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleDescreteSystemInfoBase : DoubleSystemInfoBase
  {
    protected DoubleDescreteSystemInfoBase(int dimension) : base(dimension)
    {
    }

    public override sealed SystemType Type
    {
      get { return SystemType.Discrete; }
    }
  }
}