using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring;

namespace DSIS.Scheme.Objects.Systemx
{
  [UsedBySpring]
  public class SystemSpaceParser : SchemaBasedParser<XsdSystemSpace, ISystemSpace>
  {
    public SystemSpaceParser(ObjectParserFactory factory)
      : base(factory, "resources.SystemSpace.xsd")
    {
    }

    protected override ISystemSpace Parse(XsdSystemSpace space)
    {
      return new DefaultSystemSpace(space.Dimension, space.LeftPoint, space.RightPoint, space.Division);
    }
  }
}