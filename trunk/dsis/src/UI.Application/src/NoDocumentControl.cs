using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class NoDocumentControl : UserControl, IStartableComponent, IControlWithTitle
  {
    [Autowire]
    private IMainForm MainForm { get; set; }

    [Autowire]
    private IApplicationClass App { get; set; }

    public NoDocumentControl()
    {
      Controls.Add(new Label
                     {
                       Text = "No document is opened.",
                       Dock = DockStyle.Fill,
                       TextAlign = ContentAlignment.MiddleCenter
                     });
    }

    public void Start()
    {
      SetNoContent();

      App.DocumentChanged +=
        delegate(object sender, DocumentChangedEventArgs e)
          {
            if (e.NewDocument == null)
            {
              SetNoContent();
            }
          };
    }

    private void SetNoContent()
    {
      MainForm.SetContent(this);
    }

    public Control Control
    {
      get { return this; }
    }

    public string Title
    {
      get { return "DSIS. No document is opened."; }
    }
  }
}