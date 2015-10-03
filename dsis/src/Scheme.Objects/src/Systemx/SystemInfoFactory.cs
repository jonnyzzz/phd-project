using System;
using System.Xml;
using DSIS.Core.System;
using DSIS.Spring.Util;

namespace DSIS.Scheme.Objects.Systemx
{
  public class SystemInfoFactory : AbstractRegistry<ISystemInfoFactory>
  {
    public ISystemInfo Parse(string name, XmlElement element)
    {
      return ForEach(delegate(ISystemInfoFactory instance)
                                    {
                                      if (
                                        !String.Equals(instance.FactoryName, name,
                                                       StringComparison.InvariantCultureIgnoreCase))
                                        return null;

                                      return instance.Parse(element);
                                    });
    }
  }
}