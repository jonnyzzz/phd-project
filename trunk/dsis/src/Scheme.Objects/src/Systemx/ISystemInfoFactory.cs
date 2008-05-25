using System.Xml;
using DSIS.Core.System;
using DSIS.Spring.Assemblies;

[assembly: IncludeAssembly("DSIS.Function.Predefined")]
[assembly: IncludeAssembly("DSIS.Function.Solvers")]

namespace DSIS.Scheme.Objects.Systemx
{
  public interface ISystemInfoFactory
  {
    string FactoryName { get; }

    int Dimension { get; }

    SystemType Type { get;  }

    ISystemInfo Parse(XmlElement element);
  }

  public enum SystemType
  {
    Continious,
    Descrete
  }

  public interface IContiniousFunctionSolverFactory
  {
    string MethodName { get; }
  }
}