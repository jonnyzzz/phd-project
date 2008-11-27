using DSIS.Core.Ioc;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class ConfigureWindowsForms
  {
    public ConfigureWindowsForms()
    {
      System.Windows.Forms.Application.EnableVisualStyles();
      System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
    }
  }
}