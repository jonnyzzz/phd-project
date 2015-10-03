using DSIS.Core.System;
using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring;

namespace DSIS.Scheme.Objects.Systemx
{
  [UsedBySpring]
  public class SystemInfoParser : SchemaBasedParser<XsdSystemInfo, ISystemInfo>
  {
    private readonly SystemInfoFactory myFactory;

    public SystemInfoParser(ObjectParserFactory baseFactory, SystemInfoFactory factory)
      : base(baseFactory, "resources.SystemInfo.xsd")
    {
      myFactory = factory;
    }

    protected override ISystemInfo Parse(XsdSystemInfo obj)
    {
      return myFactory.Parse(obj.Name, obj.Any);
    }
  }
}