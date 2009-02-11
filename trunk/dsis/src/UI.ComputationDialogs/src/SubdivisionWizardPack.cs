using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SubdivisionWizardPack : SimpleWizard, IWizardPack<int>
  {
    public SubdivisionWizardPack(SubdivisionWizardPage page) : base(new[] {page})
    {
      Title = "Select Subdivision and Steps";
    }

    public void Dispose()
    {
    }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public int GetResult()
    {
      return 0;
    }
  }
}