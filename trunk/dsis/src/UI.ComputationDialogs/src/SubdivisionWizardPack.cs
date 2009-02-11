using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SubdivisionWizardPack : SimpleWizard, IWizardPack<SubdivisionResult>
  {
    private readonly SubdivisionWizardPage myPage;

    public SubdivisionWizardPack(SubdivisionWizardPage page) : base(new[] {page})
    {
      myPage = page;
      Title = "Select Subdivision and Steps";
    }

    public void Dispose()
    {
    }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public SubdivisionResult GetResult()
    {
      return myPage.ControlInternal.GetResult();
    }
  }
}