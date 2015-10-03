using System.IO;
using EugenePetrenko.Shared.Core.Ioc.Api;
using log4net;

namespace DSIS.CodeCompiler
{
  [ComponentImplementation]
  public class CodeCompilerDeleteGeneratedAssemblies : IStartableComponent
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (CodeCompilerDeleteGeneratedAssemblies));
    private readonly CodeCompilerFilenameGenerator myGenerator;

    public CodeCompilerDeleteGeneratedAssemblies(CodeCompilerFilenameGenerator generator)
    {
      myGenerator = generator;
    }

    public void Start()
    {
      foreach (var file in Directory.GetFiles(myGenerator.GenerationFolder, myGenerator.GeneratedFilesWildcard))
      {
        if (File.Exists(file))
        {
          try
          {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
            LOG.DebugFormat("Delete generated file '{0}'", file);
          } catch
          {
            //Skipped.NOP;
          }
        }
      }
    }
  }
}