using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleContiniousSystemInfoBase : DoubleSystemInfoBase
  {
    protected DoubleContiniousSystemInfoBase(int dimension) : base(dimension)
    {
    }

    public override SystemType Type
    {
      get { return SystemType.Continious; }
    }
  }
}