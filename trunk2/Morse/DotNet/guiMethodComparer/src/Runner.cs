using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml;
using Eugene.Petrenko.Gui2.MethodComparer.Actions;
using Eugene.Petrenko.Gui2.MethodComparer.Parameters;
using EugenePetrenko.Gui2.Kernell2.Container;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	/// <summary>
	/// Summary description for Runner.
	/// </summary>
	public class Runner : IAttachableSimpleWriter
	{
	    private ArrayList writers = new ArrayList(); 
	    private TextWriter logWriter;
	    private TextWriter batWriter;
	    
        public Runner(string path)
        {
            path = Path.GetFullPath(path);
            
            Core core = new Core(true);
            core.ForseResourceManagerStart();
            
            logWriter = File.CreateText(Path.Combine(path, "Log.txt"));
            batWriter = File.CreateText(Path.Combine(path, "build.bat"));
            
            Assembly ass = Assembly.GetExecutingAssembly();
            XmlDocument doc = new XmlDocument();

            using(Stream stream = ass.GetManifestResourceStream("Eugene.Petrenko.Gui2.MethodComparer.xml.Items.xml"))
                doc.Load(stream);

            XmlNodeList nodes = doc.SelectNodes("items/item/@xml");
            foreach (XmlNode node in nodes)
            {
                XmlDocument param = new XmlDocument();
                using(Stream stream = ass.GetManifestResourceStream(node.Value))                
                      param.Load(stream);

                IMethodParameters load = MethodParametersSerializer.Load(param);
                
                logWriter.WriteLine("Processing {0}", load.Caption);
                
                string pathAd = Path.Combine(path, load.Caption);
                if (!Directory.Exists(pathAd))
                {
                    Directory.CreateDirectory(pathAd);
                }
                ActionPerformer pf = new ActionPerformer(this);                
                IteratedMethodsFactory fac = new IteratedMethodsFactory(load, pathAd);
                pf.Perform(fac.Task());                
            }

            WriteBuildCommand("cd {0}", path);
            
            batWriter.Close();
            logWriter.Close();
            core.Dispose();
        }
	    public static void Main(string[] args)
	    {
	        new Runner(args[0]);
	    }

	    public void WriteLine(string format, params object[] data)
	    {
	        Console.Out.WriteLine(format, data);
	        logWriter.WriteLine(format, data);
	        foreach (ISimpleWriter writer in writers)
	        {
	            writer.WriteLine(format, data);
	        }
	    }

	    public void AddHandler(ISimpleWriter wr)
	    {	        
	        writers.Add(wr);    
	    }

	    public void RemoveHandler(ISimpleWriter wr)
	    {
	        writers.Remove(wr);
	    }

	    public void WriteBuildCommand(string format, params object[] data)
	    {
	        batWriter.WriteLine(format,  data);
	    }
	}
}
