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

		public void RunGnuPlot(string filescript)
		{
			ProcessStartInfo pi = new ProcessStartInfo();
			pi.FileName = Resources.Instance.GnuplotExe;
			pi.Arguments = string.Format(Resources.Instance.GnuplotParams, filescript);
			pi.ErrorDialog = true;

			Log.LogMessage(this, "Arguments: {0} ", pi.Arguments);

			Process ps = Process.Start(pi);

			ps.Exited += new EventHandler(ps_Exited);
		}

		private void ps_Exited(object sender, EventArgs e)
		{
			Log.LogMessage(this, "GnuPlot execution finished");
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
			string fname = Resources.Instance.TempFile;
			createdFiles.Add(fname);
			return fname;
		}

		#endregion

		protected GnuPlotView(IExportData[] data, int dimension)
		{					
			switch (dimension)
			{
				case 2:
					PrepateData(data, Resources.Instance.GnuplotScript2D);
					break;
				case 3:
					PrepateData(data, Resources.Instance.GnuplotScript3D);
					break;
				default:
					Log.LogMessage(this, "Wrong Dimension in GnuPlot View");
					throw new UnableToPerformActionException();
			}
		}
		

		public void PrepateData(IExportData[] data, GnuPlotScriptGen gen)
		{
			foreach (IExportData exportData in data)
			{
				string filename = AllocateTemporaryFile();
				exportData.ExportData(filename);

				gen.addFile(filename);
			}

			string script = AllocateTemporaryFile();
			TextWriter writer = File.CreateText(script);
			writer.WriteLine(gen.ToString());
			writer.Close();

			RunGnuPlot(script);
		}

		public static GnuPlotView Visualize(IExportData data, int dimension)
		{
			return new GnuPlotView(new IExportData[]{data}, dimension );
		}

		public static GnuPlotView Visualize(IExportData[] data, int dimension)
		{
			return new GnuPlotView(data, dimension);
		}

		public static void Run()
		{
			Process.Start(Resources.Instance.GnuplotExe);
		}
	}
}