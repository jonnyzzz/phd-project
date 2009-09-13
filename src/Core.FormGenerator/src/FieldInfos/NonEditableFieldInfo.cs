using System.Reflection;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.FieldInfos;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
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