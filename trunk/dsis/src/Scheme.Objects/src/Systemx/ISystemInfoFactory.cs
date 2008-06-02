using System;
using System.Xml;
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

  public interface ISystemInfoFactory : IOptionsHolder
  {
    string FactoryName { get; }

    int Dimension { get; }


    SystemType Type { get; }

    ISystemInfo Parse(XmlElement element);
  }

  public enum SystemType
  {
    Continious,
    Descrete
  }

  public interface IContiniousFunctionSolverFactory : IOptionsHolder
  {
    string MethodName { get; }
  }
}