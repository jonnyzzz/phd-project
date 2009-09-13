using System.Reflection;
using EugenePetrenko.Core.FormGenerator.Api;
using EugenePetrenko.Core.FormGenerator.FieldInfos;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  [ComponentImplementation]
  public class TextFieldInfoFactory : FieldInfoFactoryBase<string>
  {
    protected override IFieldInfo CreateField(PropertyInfo info, object instance)
    {
      var att = info.GetCustomAttribute<TextAreaEditorPreference>();
      if (att != null)
        return new TextAreaFieldInfo(att, info, instance);

      return new TextFieldInfo(info, instance);
    }
  }
}