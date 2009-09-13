using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.FieldInfos;
using EugenePetrenko.Core.FormGenerator.Impl;
using EugenePetrenko.Core.FormGenerator.Layout;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.Impl
{
  [ComponentImplementation]
  public class FormGeneratorFactoryImpl : IFormGeneratorFactory
  {
    [Autowire]
    private IFieldInfoManager myManager { get; set; }

    [Autowire]
    private IOptionPageLayout myLayout { get; set; }

    public Control CreateForm(object data)
    {
      return new FormGenerator(myManager, data, myLayout);
    }
  }
}