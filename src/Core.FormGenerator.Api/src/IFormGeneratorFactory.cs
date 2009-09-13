using System.Windows.Forms;
using EugenePetrenko.Shared.Core.Ioc.Api;

[assembly: AssemblyWithComponents]

namespace EugenePetrenko.Core.FormGenerator.Api
{
  public interface IFormGeneratorFactory
  {
    Control CreateForm(object data);
  }
}