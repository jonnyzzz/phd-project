using System;
using DSIS.Core.System;
using DSIS.Core.System.Tree;

namespace DSIS.Function.Predefined
{
  public class SystemInfoDecoratorBase
  {
    private ISystemSpace mySystemSpace;

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