using System.Xml;
using DSIS.Core.System;
using DSIS.Spring.Assemblies;

[assembly: IncludeAssembly("DSIS.Function.Predefined")]
[assembly: IncludeAssembly("DSIS.Function.Solvers")]

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

  public interface ISystemInfoFactory : IOptionsHolder
  {
    string FactoryName { get; }

    int Dimension { get; }

    SystemType Type { get; }

    ISystemInfo Parse(XmlElement element);

    /// <summary>
    /// Creates instance of ISystemInfo using parameters specified 
    /// in object of type <see cref="IOptionsHolder.OptionsObjectType"/>
    /// </summary>
    /// <param name="parameters">parameters to the system. 
    /// Must be an instance of <see cref="IOptionsHolder.OptionsObjectType"/></param>
    /// <returns>new system info</returns>
    ISystemInfo Create(ISystemInfoParameters parameters);
  }
}