using DSIS.Core.System;
using DSIS.UI.FunctionDialog.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class SelectSystemSpaceWizardFactory
  {
    public IWizardPack<ISystemSpace> CreateWizard(ISystemInfo system)
    {
      return new SelectSystemSpaceWizard(new FixedDimensionSpaceModel(system.Dimension));
    }
  }

  public class SelectSystemSpaceWizard : SimpleWizard, IWizardPack<ISystemSpace>
  {
    private readonly SpaceModel mySpace;

    public SelectSystemSpaceWizard(SpaceModel space) : base(new[] {new SpaceControlWizardPage(space)})
    {
      Title = "Select System Space";
      mySpace = space;
    }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public ISystemSpace GetResult()
    {
      return mySpace.Create();
    }

    public void Dispose()
    {
      //TODO:
    }
  }

  public class SpaceControlWizardPage : WizardPageBase<SpaceControl>
  {
    private readonly SpaceModel myModel;

    public SpaceControlWizardPage(SpaceModel model)
    {
      myModel = model;
      ControlInternal = new SpaceControl(myModel);
      Title = "Select system space";
    }
  }
}