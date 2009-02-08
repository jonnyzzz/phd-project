using System.Reflection;
using System.Windows.Forms;
using DSIS.Utils.Bean;

namespace DSIS.UI.Wizard.FieldInfos
{
  public class TextAreaFieldInfo : TextFieldInfo
  {
    private readonly TextAreaEditorPreference myPref;

    public TextAreaFieldInfo(TextAreaEditorPreference pref, PropertyInfo property, object instance) : base(property, instance)
    {
      myPref = pref;
    }

    protected override Control UpdateTextBox(TextBox box)
    {
      box.Multiline = true;
      box.AcceptsReturn = true;
      box.AcceptsTab = true;
      box.ScrollBars = ScrollBars.Both;
      box.Height = (int)(box.Font.GetHeight() * myPref.EnsureLines) + 15;
      return base.UpdateTextBox(box);
    }
  }
}