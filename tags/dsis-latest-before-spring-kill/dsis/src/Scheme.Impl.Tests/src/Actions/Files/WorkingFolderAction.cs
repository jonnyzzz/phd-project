using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class WorkingFolderAction : ActionBase
  {
    private readonly string myPath;

    public WorkingFolderAction()
    {
      string prePath = Path.GetDirectoryName(GetType().Assembly.CodeBase);
      if (prePath.StartsWith("file:\\"))
        prePath = prePath.Substring("file:\\".Length);

      string homePath = Path.GetFullPath(Path.Combine(prePath, @"..\"));
      string workPath = Path.Combine(Path.GetFullPath(Path.Combine(homePath, @"results")),
                                     DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss"));

      if (Directory.Exists(workPath))
        Directory.Delete(workPath);

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