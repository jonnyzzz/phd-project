using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Core.Ioc.Ex;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [ComponentImplementation(Startable = true)]
  public class NoDocumentControl : UserControl, IControlWithTitle
  {
    private readonly IMainForm myMainForm;

    public NoDocumentControl(IMainForm mainForm, IApplicationClass app)
    {
      myMainForm = mainForm;

      Controls.Add(new Label
                     {
                       Text = "No document is opened.",
                       Dock = DockStyle.Fill,
                       TextAlign = ContentAlignment.MiddleCenter
                     });

      myMainForm.AfterFormCreated += delegate { SetNoContent(); };

      app.DocumentChanged +=
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
      myMainForm.SetContent(this);
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