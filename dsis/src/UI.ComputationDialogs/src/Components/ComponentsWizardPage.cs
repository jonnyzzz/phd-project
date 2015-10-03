using System.Collections.Generic;
using DSIS.Graph;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs.Components
{
  [ComponentsComponentImplementation]
  public class ComponentsWizardPage : WizardPageBase<ComponentsAndPreview>
  {
    public ComponentsWizardPage(ComponentsAndPreview page)
    {
      ControlInternal = page;
    }

    public ICollection<IStrongComponentInfo> GetSelectedComponents()
    {
      return ControlInternal.GetSelectedComponents();
    }
  }
}