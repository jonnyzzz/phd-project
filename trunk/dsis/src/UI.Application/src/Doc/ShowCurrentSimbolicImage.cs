using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.Controls.Web;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class ShowCurrentSimbolicImage : CenterControl
  {
    private readonly HtmlControl myHtml;
    private readonly IActionExecution myExec;
    private readonly IocDrawChangeAction myAction;
    private readonly IApplicationDocument myDoc;
    private readonly IInvocator myInvocator;

    private IDisposable myDrawCookie;

    public ShowCurrentSimbolicImage(IApplicationDocument doc, IocDrawChangeAction action, IActionExecution exec,
                                    IInvocator invocator)
    {
      var html = new HtmlControl {Dock = DockStyle.Fill};

      Controls.Add(html);
      myHtml = html;
      myExec = exec;
      myInvocator = invocator;
      myAction = action;
      myDoc = doc;

      myHtml.SetContext(x => x.CreateChildElement("p").CreateText("Loading"));

    }

    private void ScheduleUpdate()
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
            Size sz = ClientSize - new Size(40,40) - new Size(Padding.Left + Padding.Right, Padding.Top+Padding.Bottom);
            myExec.ExecuteAsync(
              "Draw SI",
              delegate
                {
                  myAction.Height = sz.Height;
                  myAction.Width = sz.Width;
                  var ctx = myDoc.Content;

                  if (myAction.Compatible(ctx).Empty())
                  {
                    var result = myAction.Apply(ctx);
                    if (result.ContainsKey(FileKeys.ImageKey))
                    {
                      var file = FileKeys.ImageKey.Get(result);

                      if (File.Exists(file.Path))
                      {
                        myHtml.SetContext(x => x.CreateChildElement("img")
                                                 .CreateAttribute("src", file.Path)
                                                 .CreateAttribute("alt", "Simbolic image")
                                                 .CreateAttribute("width", sz.Width + "px")
                                                 .CreateAttribute("height", sz.Height + "px")
                          );
                        return;
                      }
                    }
                  }

                  myHtml.SetContext(
                    x =>
                    x.CreateChildElement("p").CreateText(
                      "No image is supported."));
                });
          });
    }

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