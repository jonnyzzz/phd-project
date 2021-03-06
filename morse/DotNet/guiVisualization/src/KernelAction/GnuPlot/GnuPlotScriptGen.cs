using System.Text;
using EugenePetrenko.Gui2.ExternalResource.Utils;

namespace EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot
{
  /// <summary>
  /// Summary description for GnuPlotScriptGen.
  /// </summary>
  public class GnuPlotScriptGen
  {
    private GnuPlotTemplate template;
    private StringBuilder builder = new StringBuilder();
    private IGnuPlotScriptGenParameters parameters;

    private bool isFirst = true;

    public GnuPlotScriptGen(GnuPlotTemplate template, IGnuPlotScriptGenParameters parameters)
    {
      this.template = template;
      string header = " " + template.Header + " " +
                      (parameters.ShowHistory ? template.History : " ") + " " + template.Plot;

      TemplateProcessor processor = new TemplateProcessor(header);

      if (parameters != null)
      {
        processor.subsitute("width", parameters.Width.ToString());
        processor.subsitute("height", parameters.Height.ToString());
        processor.subsitute("filename", parameters.FileName);
      }
      processor.subsitute("global_title", parameters.PlotTitle);

      builder.Append(processor.ToString() + " ");

      this.parameters = parameters;
    }

    public void AddFile(string filename, string title, string showStyle)
    {
      if (!isFirst)
        builder.Append(" " + template.Delimiter + " ");

      isFirst = false;

      TemplateProcessor processor = new TemplateProcessor(" " + template.BodyTemplate + " ");
      processor.subsitute("file", filename);
      processor.subsitute("title", title);
      processor.subsitute("showStyle", showStyle);

      builder.Append(processor.ToString());
    }

    public string Generate()
    {
      string extra = "";
      if (template.Footer != null && parameters != null)
      {
        TemplateProcessor processor = new TemplateProcessor(";" + template.Footer + " ");

        processor.subsitute("width", parameters.Width.ToString());
        processor.subsitute("height", parameters.Height.ToString());
        processor.subsitute("filename", parameters.FileName);

        extra = processor.ToString();
      }

      return builder.ToString() + extra;
    }
  }
}