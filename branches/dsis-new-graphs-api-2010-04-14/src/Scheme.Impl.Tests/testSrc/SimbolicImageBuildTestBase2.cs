using DSIS.Core.System;
using NUnit.Framework;

namespace DSIS.Scheme.Impl.Tests
{
  public abstract class SimbolicImageBuildTestBase2 : SimbolicImageBuildTestBase
  {
    protected ISystemInfo mySystemInfo;
    protected ISystemSpace mySystemSpace;

    protected override ISystemInfo SystemInfo
    {
      get { return mySystemInfo; }
    }

    protected override ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
    }

    [TearDown]
    public virtual void TearDown()
    {
      mySystemInfo = null;
      mySystemSpace = null;
    }
  }
}