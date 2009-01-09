using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class UserDefinedSystemInfoFactory : ISystemInfoFactoryProvider
  {
    public string Name
    {
      get { return "User defined"; }
    }

    public string Description
    {
      get { return "Alows to create new system and use it throuh the system"; }
    }

    public bool Enabled
    {
      get { return false; }
    }

    public IWizardPack<ISystemInfo> CreateWizard()
    {
      throw new System.NotImplementedException();
    }
  }
}