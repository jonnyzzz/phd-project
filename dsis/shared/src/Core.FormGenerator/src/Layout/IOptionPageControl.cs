using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.Layout
{
  public interface IOptionPageControl
  {
    string Title { get;}
    string Description { get;}

    Control Control{ get;}
  }
}