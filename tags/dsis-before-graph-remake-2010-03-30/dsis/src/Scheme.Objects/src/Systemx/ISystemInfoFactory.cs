using DSIS.Core.System;
namespace DSIS.Scheme.Objects.Systemx
{
  /// <summary>
  /// Implement interface to provide default system Information
  /// </summary>
  public interface ISystemInfoPredefinedFactory
  {
    string Name { get; }
    ISystemSpace Space { get; }
    ISystemInfo Function { get; }
  }

  public interface ISystemInfoFactory : IOptionsHolder, IOptionsBasedFactory<ISystemInfoParameters, ISystemInfo>
  {
    int Dimension { get; }

    SystemType Type { get; }
  }
}