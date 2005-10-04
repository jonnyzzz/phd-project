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
		private GnuPlotScriptGenParameters parameters;

		private bool isFirst = true;

		public GnuPlotScriptGen(GnuPlotTemplate template, GnuPlotScriptGenParameters parameters, string title)
		{
			this.template = template;
			TemplateProcessor processor = new TemplateProcessor(" " + template.Header + " ");
				
			if (parameters != null) 
			{
				processor.subsitute("width", parameters.Width.ToString());
				processor.subsitute("height", parameters.Height.ToString());
				processor.subsitute("filename", parameters.FileName);
			}
			processor.subsitute("global_title", title);			
			
			builder.Append(processor.ToString() + " ");

			this.parameters = parameters;
		}

		public void addFile(string filename, string title)
		{
			if (!isFirst)
				builder.Append(" "  + template.Delimiter + " ");

			isFirst = false;

			TemplateProcessor processor = new TemplateProcessor(" " + template.BodyTemplate + " ");
			processor.subsitute("file", filename);
			processor.subsitute("title", title);			

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
