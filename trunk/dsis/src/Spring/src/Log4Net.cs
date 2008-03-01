using System;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Config;

namespace DSIS.Spring
{
  [UsedBySpring]
  public class Log4NetConfigurator : IDisposable
  {
    private const string LOG_4_NET_CONFIG = "log4net-config.xml";
    private const string LOG_ENV_KEY = "log-file";

    private Log4NetConfigurator()
    {
      string home = Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath);

      SetFile(Path.Combine(home, "Logs"));
      
      FileInfo file = new FileInfo(Path.Combine(home, LOG_4_NET_CONFIG));
      if (file.Exists)
      {
        XmlConfigurator.Configure(file);
      }
      else
      {
        using (Stream str = GetType().Assembly.GetManifestResourceStream(GetType(), "resources.log4net.xml"))
        {
          XmlConfigurator.Configure(str);
        }
      }

      ILog LOG = LogManager.GetLogger(GetType());
      LOG.InfoFormat("Started log4net from {0}", file.FullName);
    }

    private static void SetFile(string home)
    {
      string destPath = home;
      if (destPath == null)
        destPath = Path.Combine(Path.GetTempPath(), "DSIS");

      if (!Directory.Exists(destPath))
        Directory.CreateDirectory(destPath);

      Process process = Process.GetCurrentProcess();
      string sLogId = process.StartTime.ToString("s").Replace(":", "-").Replace(".", "-");
      // An ISO8601 time string, fitted for file names
      string sProcessName = process.ProcessName.Replace(".", "_");
      string logFile =
        Path.Combine(destPath,
                     string.Format("{0}.{1}.{2}#{3}-{4}.log", "teamcity-dotnet-listeners", sLogId, sProcessName,
                                   process.Id, (DateTime.Now - new DateTime(2008, 02, 05, 16, 22, 10)).Ticks));

      string newLogFile = logFile;
      int i = 1;
      while (File.Exists(newLogFile))
      {
        newLogFile = logFile + "." + i;
      }
      Environment.SetEnvironmentVariable(LOG_ENV_KEY, newLogFile);
    }

    public static void SetUp()
    {
      new Log4NetConfigurator();
    }

    public static void Dispose()
    {
      LogManager.Shutdown();
    }

    void IDisposable.Dispose()
    {
      Dispose();
    }
  }
}