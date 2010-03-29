using System.Windows.Forms;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public interface IOptionPageControl
  {
    string Title { get;}
    string Description { get;}

    Control Control{ get;}
  }
}