using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DSIS.UI.Application.Progress;
using DSIS.UI.Controls.Web;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  public abstract class ImageDrawingControl : UserControl
  {
    private readonly HtmlControl myHtml;
    private readonly IActionExecution myExec;
    private readonly IInvocator myInvocator;
    private IDisposable myDrawCookie;

    protected ImageDrawingControl(IActionExecution exec, IInvocator invocator)
    {
      myHtml = new HtmlControl { Dock = DockStyle.Fill };
      myExec = exec;
      myInvocator = invocator;
      Controls.Add(myHtml);

      myHtml.SetContext(x => x.CreateChildElement("p").CreateText("Loading"));
    }

    protected override void Dispose(bool disposing)
    {
      myDrawCookie.SafeDispose();

      base.Dispose(disposing);
    }

    protected void ScheduleUpdate()
    {
      if (myDrawCookie != null)
      {
        myDrawCookie.Dispose();
        myDrawCookie = null;
      }

      myDrawCookie = myInvocator.ExecuteWithTimeout(
        "Draw SI",
        TimeSpan.FromSeconds(.5),
        ()
        =>
          {
            if (!IsHandleCreated)
            {
              ScheduleUpdate();
              return;
            }
            Size sz = ClientSize - new Size(40,40) - new Size(Padding.Left + Padding.Right, Padding.Top+Padding.Bottom);
            myExec.ExecuteAsync(
              "Draw SI",
              delegate
                {
                  string file = DrawImage(sz);
                  if (file != null && File.Exists(file))
                  {
                    myHtml.SetContext(x => x.CreateChildElement("img")
                                             .CreateAttribute("src", file)
                                             .CreateAttribute("alt", "Simbolic image")
                                             .CreateAttribute("width", sz.Width + "px")
                                             .CreateAttribute("height", sz.Height + "px")
                      );
                  }
                  else
                  {
                    myHtml.SetContext(
                      x =>
                      x.CreateChildElement("p").CreateText(
                        "No image is supported."));
                  }
                });
          });
    }

    protected abstract string DrawImage(Size sz);

    protected override void OnInvalidated(InvalidateEventArgs e)
    {
      base.OnInvalidated(e);
      ScheduleUpdate();
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      ScheduleUpdate();
    }
  }
}