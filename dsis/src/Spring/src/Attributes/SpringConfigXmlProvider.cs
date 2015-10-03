using System.Collections.Generic;
using DSIS.Spring.Config;
using DSIS.Spring.Util;

namespace DSIS.Spring.Attributes
{
  [UsedBySpring]
  public class SpringConfigXmlProvider : Registrar<ISpringConfigProvider, SpringConfigRegistry>, ISpringConfigProvider
  {
    private readonly TempFileManager myTempFiles;

    private readonly SpringXmlConfigWriter myWriter;
    public SpringConfigXmlProvider(SpringConfigRegistry factory, SpringXmlConfigWriter myWriter, TempFileManager myTempFiles) : base(factory)
    {
      this.myWriter = myWriter;
      this.myTempFiles = myTempFiles;
    }

    public IEnumerable<string> GetSpringConfigPaths()
    {
      string tempFile = myTempFiles.GetTempFile();
      myWriter.WriteConfig(tempFile);

      yield return tempFile;
    }
  }
}