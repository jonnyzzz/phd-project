using System.Windows.Forms;

namespace DSIS.UI.UI
{
  public delegate T WithForm<T>(Form form);

  public delegate void WithForm(Form form);

  public interface IApplicationClass
  {
    T ShowDialog<T>(WithForm<T> action);
    void ShowDialog(WithForm action);
  }
}