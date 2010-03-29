namespace DSIS.UI.Wizard.ListSelector
{
  public interface IListSelectorWizardPage<Q> : IWizardPage
  {
    Q SelectedItem { get; set; }
  }
}