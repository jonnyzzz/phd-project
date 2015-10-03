using DSIS.Core.System;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
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
}