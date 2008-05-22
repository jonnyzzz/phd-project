using System.Xml;
using DSIS.Core.System;
using DSIS.Spring.Assemblies;

[assembly: IncludeAssembly("DSIS.Function.Predefined")]
namespace DSIS.Scheme.Objects.Systemx
{
  public interface ISystemInfoFactory
  {
    string FactoryName { get; }
    ISystemInfo Parse(XmlElement element);
  }
}