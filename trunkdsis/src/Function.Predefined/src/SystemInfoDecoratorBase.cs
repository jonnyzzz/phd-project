using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public class SystemInfoDecoratorBase
  {
    private readonly ISystemSpace mySystemSpace;

    public SystemInfoDecoratorBase(ISystemSpace systemSpace)
    {
      mySystemSpace = systemSpace;
    }

    public ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
    }
  }
}