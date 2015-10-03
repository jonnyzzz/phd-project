using System;

namespace DSIS.UI.Wizard
{
  public interface IWizardPack<T> : IDisposable
  {
    IWizardPack Controller { get; }
    T GetResult();
  }

  public interface IWizardPackFactory<T>
  {
    IWizardPack<T> CreateWizard();
  }
}