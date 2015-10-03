using System.Collections.Generic;
using System.IO;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class WorkingFolderActionBase : ActionBase
  {
    protected string myPath;
    protected abstract string CreateWorkPath(string resultsPath);

    protected WorkingFolderActionBase()
    {
      string prePath = Path.GetDirectoryName(GetType().Assembly.CodeBase);
      if (prePath.StartsWith("file:\\"))
        prePath = prePath.Substring("file:\\".Length);

      string homePath = Path.GetFullPath(Path.Combine(prePath, @"..\"));
      var resultsPath = Path.GetFullPath(Path.Combine(homePath, @"results"));
      string workPath = CreateWorkPath(resultsPath);

      if (!Directory.Exists(workPath))
        Directory.CreateDirectory(workPath);

      myPath = workPath;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      FileKeys.WorkingFolderKey.Set(result, new WorkingFolderInfo(myPath));
    }
  }
}