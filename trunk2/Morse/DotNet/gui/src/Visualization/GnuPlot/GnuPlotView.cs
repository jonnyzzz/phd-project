using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using gui.Logger;
using gui.Resource;
using gui.Tree.Node.Action;
using MorseKernelATL;

namespace gui.Visualization.GnuPlot
{
	/// <summary>
	/// Summary description for GnuPlotView.
	/// </summary>
	public class GnuPlotView
	{
		private ArrayList createdFiles = new ArrayList();

		#region runner

		public void showFromFile(string filedata, string filetemplate)
		{
			ProcessStartInfo pi = new ProcessStartInfo();
			pi.FileName = Resources.Instance.Gnuplot_Exe;
			pi.Arguments = string.Format(Resources.Instance.Gnuplot_Exe_Params, filetemplate, filedata);
			pi.ErrorDialog = true;

			Log.LogMessage(this, "Arguments: {0} ", pi.Arguments);

			Process ps = Process.Start(pi);

			ps.Exited += new EventHandler(ps_Exited);
		}

		private void ps_Exited(object sender, EventArgs e)
		{
			foreach (string file in createdFiles)
			{
				try
				{
					File.Delete(file);
				}
				catch (Exception)
				{
				}
				;
			}
		}

		public string AllocateTemporaryFile()
		{
			string fname = Resources.Instance.TempFile();
			createdFiles.Add(fname);
			return fname;
		}

		#endregion

		private IGraphInfo info;
		private string filedata;

		protected GnuPlotView(IExportData data, IGraphInfo info)
		{
			filedata = AllocateTemporaryFile();
			data.ExportData(filedata);

			this.info = info;
			switch (info.dimension())
			{
				case 2:
					showFromFile(filedata, createTemplate2D());
					break;
				case 3:
					showFromFile(filedata, createTemplate3D());
					break;
				default:
					throw new UnableToPerformActionException();
			}
		}

		public string createTemplate2D()
		{
			TemplateProcessor tp = new TemplateProcessor(ResourceLoader.LoadResourceAsText(Resources.Instance.Gnuplot_Template_2D));
			tp.subsitute("x_min", (info.spaceMin(0) - info.gridSize(0)/2).ToString().Replace(',', '.'));
			tp.subsitute("x_max", (info.spaceMax(0) + info.gridSize(0)/2).ToString().Replace(',', '.'));
			tp.subsitute("y_min", (info.spaceMin(1) - info.gridSize(1)/2).ToString().Replace(',', '.'));
			tp.subsitute("y_max", (info.spaceMax(1) + info.gridSize(1)/2).ToString().Replace(',', '.'));
			tp.subsitute("file", filedata);
			tp.subsitute("x_offset", (info.gridSize(0)/2).ToString().Replace(',', '.'));
			tp.subsitute("y_offset", (info.gridSize(1)/2).ToString().Replace(',', '.'));
			tp.subsitute("x_size", (info.gridSize(0)).ToString().Replace(',', '.'));
			tp.subsitute("y_size", (info.gridSize(0)).ToString().Replace(',', '.'));

			string name = AllocateTemporaryFile();
			TextWriter tw = File.CreateText(name);
			tw.WriteLine(tp.ToString());
			tw.Flush();
			tw.Close();
			return name;
		}

		public string createTemplate3D()
		{
			TemplateProcessor tp = new TemplateProcessor(ResourceLoader.LoadResourceAsText(Resources.Instance.Gnuplot_Template_3D));

			tp.subsitute("file", filedata);
			tp.subsitute("x_offset", (info.gridSize(0)/2).ToString().Replace(',', '.'));
			tp.subsitute("y_offset", (info.gridSize(1)/2).ToString().Replace(',', '.'));
			tp.subsitute("z_offset", (info.gridSize(2)/2).ToString().Replace(',', '.'));

			string name = AllocateTemporaryFile();
			TextWriter tw = File.CreateText(name);
			tw.WriteLine(tp.ToString());
			tw.Flush();
			tw.Close();
			return name;
		}

		public static GnuPlotView ShowFromFile(IGraphInfo info, IExportData data)
		{
			return new GnuPlotView(data, info);
		}

		public static void Run()
		{
			Process.Start(Resources.Instance.Gnuplot_Exe);
		}
	}
}