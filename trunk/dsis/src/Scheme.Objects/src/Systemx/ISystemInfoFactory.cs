using System;
using System.Xml;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Spring.Assemblies;
using DSIS.Utils.Bean;

[assembly: IncludeAssembly("DSIS.Function.Predefined")]
[assembly: IncludeAssembly("DSIS.Function.Solvers")]

namespace DSIS.Scheme.Objects.Systemx
{
  public interface IOptionsHolder
  {
    /// <summary>
    /// Object providing options to create the system.
    /// Null is the place for no options.
    /// New instance of that object will be created for UI
    /// Values will be filled according to <see cref="IncludeGenerateAttribute"/>
    /// field markers
    /// </summary>
    Type OptionsObjectType { get; }
  }

  /// <summary>
  /// Marker interface for all SystemInfo creation parameter classes.
  /// Implementations should be serializable.
  /// </summary>  
  public interface ISystemInfoParameters
  {
  }

  /// <summary>
  /// Marker interface for all SystemInfo creation parameter classes.
  /// </summary>
  public interface IContiniousSolverParameters
  {
  }

  public class SystemInfoComponent : ComponentImplementationAttribute
  {
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

  public enum SystemType
  {
    Continious,
    Descrete
  }

  [ComponentCollection]
  public interface IContiniousFunctionSolverFactory : IOptionsHolder
  {
    string MethodName { get; }

    /// <summary>
    /// Creates instance of ISystemInfo using parameters specified 
    /// in object of type <see cref="IOptionsHolder.OptionsObjectType"/>
    /// </summary>
    /// <param name="system">System to integrate</param>
    /// <param name="parameters">parameters to the system. 
    /// Must be an instance of <see cref="IOptionsHolder.OptionsObjectType"/></param>
    /// <returns>new system info</returns>
    ISystemInfo Create(ISystemInfo system, IContiniousSolverParameters parameters);
  }
}