using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Text;
using MorseKernelATL;

namespace gui.src.Visualization.GnuPlot
{
	/// <summary>
	/// Summary description for GnuPlotView.
	/// </summary>
	public class GnuPlotView
	{
        private readonly string GNUPLOT_EXE = @"bin\wgnuplot.exe";

		public GnuPlotView()
		{
		}

        private string createDrawCommand(string file)
        {
            string name = AllocateTemporaryFile();
            TextWriter tw = File.CreateText(name);
            tw.WriteLine("plot \'{0}\'", file);
            tw.Flush();
            tw.Close();
            return "-noend " + name + " -";
        }

        public void showFromFile(string file)
        {
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.FileName = Resources.Resources.GNUPLOT_PATH + GNUPLOT_EXE;            
            pi.Arguments = createDrawCommand(file);

            Logger.Logger.Log("Run params {0}", pi);


            Process ps = Process.Start(pi);
            
           // Logger.Logger.Log(dump(ps));
            
            //Logger.Logger.Log("Process {0} was started with parameters {1}", ps, pi);            
        }

        private string dump(Process ps)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Exit code : {0}" , ps.ExitCode);
            sb.AppendFormat("Error :");
            StreamReader sr = ps.StandardError;
            string s;
            while ((s = sr.ReadLine()) != null) sb.AppendFormat("-->:{0}", s);
            sb.Append("End");

            sb.AppendFormat("out :");
            sr = ps.StandardError;            
            while ((s = sr.ReadLine()) != null) sb.AppendFormat("-->:{0}", s);
            sb.Append("End");
            
            return sb.ToString();
        }


        public static string AllocateTemporaryFile()
        {
            //return System.IO.Path.GetTempFileName();
            return @"o:\" + DateTime.UtcNow.Millisecond + "." + DateTime.UtcNow.Second + "." + DateTime.UtcNow.Minute + "." + DateTime.UtcNow.Hour;
        }

        public static GnuPlotView ShowFromFile(string file)
        {
            GnuPlotView gw = new GnuPlotView();            
            gw.showFromFile(file);
            return gw;
        }

        public static void Visualize(IExportData data)
        {
            
        }

	}
}
