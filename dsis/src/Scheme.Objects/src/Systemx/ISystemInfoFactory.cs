using System.Xml;
using DSIS.Core.System;
using DSIS.Spring;

[assembly: SpringIncludeAssembly("DSIS.Function.Predefined")]
namespace DSIS.Scheme.Objects.Systemx
{
  public interface ISystemInfoFactory
  {
    string FactoryName { get; }
    ISystemInfo Parse(XmlElement element);
  }
}