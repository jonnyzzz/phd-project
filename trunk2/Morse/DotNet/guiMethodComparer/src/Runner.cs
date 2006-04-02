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
	    
        public Runner(string path, IRunMode mode)
        {
            path = Path.GetFullPath(path);
            
            Core core = new Core(true);
            core.ForseResourceManagerStart();
            
            logWriter = File.CreateText(Path.Combine(path, "Log.txt"));
            batWriter = File.CreateText(Path.Combine(path, "build.bat"));
                        
            foreach (XmlDocument task in mode.Items)
            {			
            	IMethodParameters load = MethodParametersSerializer.Load(task);
                
                logWriter.WriteLine("Processing {0}", load.Caption);
                logWriter.WriteLine("\r\n Parameters Dump:");
				task.Save(logWriter);
                logWriter.WriteLine("End\r\n\r\n");
                
                string pathAd = Path.Combine(path, load.Caption);
                if (!Directory.Exists(pathAd))
                {
                    Directory.CreateDirectory(pathAd);
                }
                ActionPerformer pf = new ActionPerformer(this, task);
                IteratedMethodsFactory fac = new IteratedMethodsFactory(load, pathAd);
                pf.Perform(fac.Task(), pathAd);
            }

            WriteBuildCommand("cd {0}", path);
            
            batWriter.Close();
            logWriter.Close();
            core.Dispose();
        }


	    public static void Main(string[] args)
	    {
			CommandLineParser cmd = new CommandLineParser(args);

			if (cmd.HasKey("file"))
			{
				new Runner(cmd.GetValue("path"), new UserFileRunMode(cmd));
			} else
			{
				new Runner(cmd.GetValue("path"), new PredefinedRunMode(cmd));
			}			
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
