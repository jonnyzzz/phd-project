using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.UI.FunctionDialog
{
  public class SelectPredefinedSystemPage : ListSelectorBase<ISystemInfoFactory>
  {
    public SelectPredefinedSystemPage(IEnumerable<ISystemInfoFactory> factories) : base(factories)
    {
    }

    protected override string FactoryName(ISystemInfoFactory factory)
    {
      return string.Format("{0}\r\nDimension:{1}, Type:{2}",factory.FactoryName, factory.Dimension, factory.Type);
    }
  }
}