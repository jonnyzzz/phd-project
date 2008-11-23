using System.Reflection;
using System.Windows.Forms;

namespace DSIS.UI.Wizard.FormsGenerator
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