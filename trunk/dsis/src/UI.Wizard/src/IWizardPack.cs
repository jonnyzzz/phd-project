namespace DSIS.UI.Wizard
{
  public interface IWizardPack
  {
    /// <summary>
    /// Global title to be shown for user
    /// </summary>
    string Title { get; }

    /// <summary>
    /// First page to be shown
    /// </summary>
    IWizardPage FirstPage { get; }

    /// <summary>
    /// Dinamical condition to check weather this page can be the exit page. 
    /// Finish button will be active
    /// </summary>
    /// <param name="page">The page to check</param>
    /// <returns>true iff that is exit page for dialog</returns>
    bool IsLastPage(IWizardPage page);

    /// <summary>
    /// Returns the next page if there is some.
    /// It is assumed to return cached result for every call with same argument
    /// </summary>
    /// <param name="page">Page to compute next page</param>
    /// <returns>Next page or null</returns>
    IWizardPage Next(IWizardPage page);

    /// <summary>
    /// Called when user pressed 'Finish' button on some page where <see cref="IsLastPage"/> returned true
    /// </summary>
    void OnFinish();

    /// <summary>
    /// Called if user cancel the dialod.
    /// </summary>
    void OnCancel();

    /// <summary>
    /// Called before page is shown. 
    /// This may be next page or prev page
    /// </summary>
    /// <param name="page"></param>
    void PageShown(IWizardPage page);
  }
}