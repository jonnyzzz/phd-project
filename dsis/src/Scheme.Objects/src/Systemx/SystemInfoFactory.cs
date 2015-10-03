using System;
using System.Xml;
using DSIS.Core.System;

namespace DSIS.Scheme.Objects.Systemx
{
  public class SystemInfoFactory //: AbstractRegistry<ISystemInfoFactory>
  {
    public ISystemInfo Parse(string name, XmlElement element)
    {
      throw new NotImplementedException();
      /*return ForEach(delegate(ISystemInfoFactory instance)
                                    {
                                      if (
                                        !String.Equals(instance.FactoryName, name,
                                                       StringComparison.InvariantCultureIgnoreCase))
                                        return null;

                                      return instance.Parse(element);
                                    });*/
    }
  }
}