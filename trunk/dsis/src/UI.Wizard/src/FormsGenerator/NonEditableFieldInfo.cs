using System.Reflection;
using System.Windows.Forms;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class NonEditableFieldInfo : FieldInfoBase
  {
    public NonEditableFieldInfo(string caption, string description, PropertyInfo property, object instance) : base(caption, description, property, instance)
    {
    }

    protected override Control CreateControl()
    {
      return new Label {Text = "There is no editor for type " + PropertyType};
    }
  }
}