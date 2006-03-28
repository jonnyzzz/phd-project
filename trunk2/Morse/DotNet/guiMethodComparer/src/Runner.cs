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
	public class Runner : IAttachableSimpleWriter
	{
	    private ArrayList writers = new ArrayList(); 
	    private TextWriter logWriter;
	    private TextWriter batWriter;
	    
        public Runner(string path, string[] methods)
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

            XmlNodeList nodes = doc.SelectNodes("items/item");
            foreach (XmlNode node in nodes)
            {
                XmlDocument param = new XmlDocument();
                using(Stream stream = ass.GetManifestResourceStream(node.Attributes["xml"].Value))                
                      param.Load(stream);

				bool flag = false;
            	foreach (string method in methods)
            	{
                    if (method.ToUpper() == node.Attributes["name"].Value.ToUpper())
                    {
                    	flag = true;
						break;
                    }
            	}
				if (!flag && methods.Length != 0)
					continue;

            	IMethodParameters load = MethodParametersSerializer.Load(param);
                
                logWriter.WriteLine("Processing {0}", load.Caption);
                logWriter.WriteLine("\r\n Parameters Dump:");
                logWriter.WriteLine(param.OuterXml);
                logWriter.WriteLine("End\r\n\r\n");
                
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
			if (args.Length > 0) 
			{
				ArrayList list = new ArrayList();
				for (int i=1; i<args.Length; i++) 
					list.Add(args[i]);

				new Runner(args[0], (string[]) list.ToArray(typeof(string)) );
			}
			else
				Console.Out.WriteLine("Specify path to run");
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
