using System;
using System.IO;
using DSIS.Core.Ioc;

namespace DSIS.CodeCompiler
{
  [ComponentImplementation]
  public class CodeCompilerFilenameGenerator
  {
    public string GenerationFolder
    {
      get { return Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath); }
    }

    public string GenerateName()
    {
      return Path.Combine(GenerationFolder, "DSIS.Generated.Assembly." + Guid.NewGuid() + ".dll");
    }

    public string GeneratedFilesWildcard
    {
      get { return "DSIS.Generated.Assembly.*"; }
    }
  }
}