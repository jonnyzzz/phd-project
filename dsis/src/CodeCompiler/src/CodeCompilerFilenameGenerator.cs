using System;
using System.IO;
using DSIS.Core.Ioc;

namespace DSIS.CodeCompiler
{
  [ComponentImplementation]
  public class CodeCompilerFilenameGenerator
  {
    private const string GENERATED_NAME = "DSIS.Generated.Assembly.";     
    private const string GENERATED_FILES_WILDCARD = GENERATED_NAME + "*";     

    public string GenerationFolder
    {
      get { return Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath); }
    }

    public string GenerateName()
    {
      return Path.Combine(GenerationFolder, GENERATED_NAME + Guid.NewGuid() + ".dll");
    }

    public string GeneratedFilesWildcard
    {
      get { return GENERATED_FILES_WILDCARD; }
    }
    
    public static void DeleteAllGeneratedFiles()
    {
      var path = typeof(CodeCompilerFilenameGenerator).Assembly.CodeBase;
      foreach (var file in Directory.GetFiles(Path.GetDirectoryName(new Uri(path).LocalPath), GENERATED_FILES_WILDCARD))
      {
        try
        {
          File.SetAttributes(file, FileAttributes.Normal);
          File.Delete(file);
        } catch
        {
          ;//
        }
      }
    }
  }
}