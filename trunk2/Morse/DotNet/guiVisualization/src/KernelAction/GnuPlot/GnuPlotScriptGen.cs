using System;
using System.Text;
using guiExternalResource.Utils;
using guiVisualization.KernelAction.GnuPlot;

namespace gui.Resource
{
	/// <summary>
	/// Summary description for GnuPlotScriptGen.
	/// </summary>
	public class GnuPlotScriptGen
	{
		private GnuPlotTemplate template;
		private StringBuilder builder = new StringBuilder();

		private bool isFirst = true;

		public GnuPlotScriptGen(GnuPlotTemplate template)
		{
			this.template = template;
			builder.Append(template.Header + " ");
		}

		public void addFile(string filename)
		{
			if (!isFirst)
				builder.Append(" "  + template.Delimiter + " ");

			isFirst = false;

			TemplateProcessor processor = new TemplateProcessor(" " + template.BodyTemplate + " ");
			processor.subsitute("file", filename);

			builder.Append(processor.ToString());
		}

		public override string ToString()
		{
			return builder.ToString();
		}
	}
}
