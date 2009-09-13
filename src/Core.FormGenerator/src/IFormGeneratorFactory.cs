using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator
{
  public interface IFormGeneratorFactory
  {
    Control CreateForm(object data);
  }
}