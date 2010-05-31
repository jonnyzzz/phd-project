using System.Reflection;
using DSIS.Core.Ioc;
using DSIS.Utils;
using DSIS.Utils.Bean;

namespace DSIS.UI.Wizard.FieldInfos
{
  [ComponentImplementation]
  public class TextFieldInfoFactory : FieldInfoFactoryBase<string>
  {
    protected override IFieldInfo CreateField(PropertyInfo info, object instance)
    {
      var att = info.OneInstance<TextAreaEditorPreference>();
      if (att != null)
        return new TextAreaFieldInfo(att, info, instance);

      return new TextFieldInfo(info, instance);
    }
  }
}