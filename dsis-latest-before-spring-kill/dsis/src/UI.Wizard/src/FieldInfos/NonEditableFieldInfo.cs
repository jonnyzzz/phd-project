using System.Reflection;
using System.Windows.Forms;
using DSIS.UI.Wizard.FieldInfos;

namespace DSIS.UI.Wizard.FieldInfos
{
  public class NonEditableFieldInfo : FieldInfoBase
  {
    public NonEditableFieldInfo(PropertyInfo property, object instance) : base(property, instance)
    {
    }

    protected override Control CreateControl()
    {
      return new Label {Text = "There is no editor for type " + PropertyType.FullName};
    }
  }
}