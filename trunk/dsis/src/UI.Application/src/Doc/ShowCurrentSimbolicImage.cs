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
    public ShowCurrentSimbolicImage(IApplicationDocument doc, IocDrawChangeAction action, IActionExecution exec)
    {
      var html = new HtmlControl {Dock = DockStyle.Fill};
      var ctx = doc.Content;

      Controls.Add(html);

      exec.ExecuteAsync(
        "Draw SI",
        delegate
          {
            if (action.Compatible(ctx).Empty())
            {
              var result = action.Apply(ctx);
              if (result.ContainsKey(FileKeys.ImageKey))
              {
                var file = FileKeys.ImageKey.Get(result);

                if (File.Exists(file.Path))
                {
                  html.SetContext(x => x.CreateChildElement("img")
                                         .CreateAttribute("src", file.Path)
                                         .CreateAttribute("alt", "Simbolic image")
                                         .CreateAttribute("width", "99%")
                                         .CreateAttribute("height", "99%")
                    );
                  return;
                }
              }
            }
            
            html.SetContext(x => x.CreateChildElement("p").CreateText("No image is supported."));
          });
    }
  }
}