using System.IO;
using DSIS.Core.Ioc;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class WorkingFolderInfoImpl : WorkingFolderInfo
  {
    public WorkingFolderInfoImpl() : base(GetTempFolder())
    {
    }

    private static string GetTempFolder()
    {
      var folder = typeof(WorkingFolderInfoImpl).Assembly.Location;
      var result = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(folder), "Temp");
      if (Directory.Exists(result))
        Directory.Delete(result, true);

      Directory.CreateDirectory(result);
      return result;
    }
  }
}