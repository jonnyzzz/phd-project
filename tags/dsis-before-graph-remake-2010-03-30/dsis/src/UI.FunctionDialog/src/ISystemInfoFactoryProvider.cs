using DSIS.Core.System;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  /// <summary>
  /// Defines a way of how to create system info function wizard.
  /// One is predefined system,
  /// possible implementataions could be: Predefined, Used-defined, something else
  /// </summary>
  public interface ISystemInfoFactoryProvider
  {
    string Name { get; }
    string Description { get; }

    bool Enabled { get; }

    IWizardPack<ISystemInfo> CreateWizard();
  }
}