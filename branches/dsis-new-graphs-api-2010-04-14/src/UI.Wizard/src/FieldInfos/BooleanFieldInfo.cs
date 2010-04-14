using System;
using System.Reflection;
using System.Windows.Forms;
using DSIS.Core.Ioc;

namespace DSIS.UI.Wizard.FieldInfos
{
  [ComponentImplementation]
  public class BooleanFieldInfoFactory : FieldInfoFactoryBase<bool>
  {
    protected override IFieldInfo CreateField(PropertyInfo info, object instance)
    {
      return new BooleanFieldInfo(info, instance);
    }
  }

  public class BooleanFieldInfo : FieldInfoBase
  {
    public BooleanFieldInfo(PropertyInfo property, object instance) : base(property, instance)
    {
      if (PropertyType != typeof(bool))
        throw new ArgumentException("Boolean type expected but was " + PropertyType + " for " + property);
    }

    protected override Control CreateControl()
    {
      var control = new CheckBox {Checked = (bool) Value};
      control.CheckedChanged += delegate
                                  {
                                    Value = control.Checked;
                                  };
      return control;
    }
  }
}