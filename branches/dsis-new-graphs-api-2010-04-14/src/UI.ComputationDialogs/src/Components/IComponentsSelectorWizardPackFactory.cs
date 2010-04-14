using System.Collections.Generic;
using DSIS.Graph;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs.Components
{
  public interface IComponentsSelectorWizardPackFactory
  {
    IWizardPack<ICollection<IStrongComponentInfo>> CreateWizard(IGraphStrongComponents comps);
  }
}