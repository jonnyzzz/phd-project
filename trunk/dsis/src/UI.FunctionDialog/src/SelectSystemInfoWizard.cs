using System;
using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.ListSelector;
using DSIS.UI.Wizard.OptionsWizard;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class SelectSystemInfoWizard : OptionsBasedWizard<ISystemInfoParameters, ISystemInfo, ISystemInfoFactory>
  {
    public SelectSystemInfoWizard(
      IListSelectorWizardPageFactory listFactory, 
      IEnumerable<ISystemInfoFactory> factories) : 
        base("Select predefined system", listFactory, factories, x=>true)
    {
    }

    protected override ItemDescr GetFactoryName(ISystemInfoFactory x)
    {
      return new ItemDescr(x.FactoryName, string.Format("Dimension: {0}, Type: {1}", x.Dimension, x.Type));
    }

    protected override Comparison<ISystemInfoFactory> Comparer
    {
      get
      {
        return delegate(ISystemInfoFactory x, ISystemInfoFactory y)
        {
          var v = x.Type.CompareTo(y.Type);
          if (v != 0) return -v;

          v = x.Dimension.CompareTo(y.Dimension);
          if (v != 0) return v;

          return x.FactoryName.CompareTo(y.FactoryName);
        };
      }
    }
  }
}