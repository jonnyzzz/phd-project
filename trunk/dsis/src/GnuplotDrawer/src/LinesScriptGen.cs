using System;
using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{
  public class LinesScriptGen : PngWriterBase, IGnuplotLineScriptGen
  {
    private readonly Dictionary<string, int> myCriteriaToCode = new Dictionary<string, int>();
    private bool myIsFirst = true;
    private readonly Func<string, LinePointsFile> CreateCriteriaFileName;

    public LinesScriptGen(ITempFileFactory factory, string suffix, GnuplotScriptParameters ps) : base(factory, ps)
    {
      myWriter.Write("plot ");
      CreateCriteriaFileName =
        name =>
          {
            int v;
            if (!myCriteriaToCode.TryGetValue(name, out v))
            {
              v = myCriteriaToCode[name] = myCriteriaToCode.Count + 1;
            }
            return new LinePointsFile(factory, suffix + v + ".dat", 2, name);
          };
    }

    public void AddSeria(string name, IEnumerable<double> values)
    {
      var w = CreateCriteriaFileName(name);
      int count = 0;
      foreach (double v in values)
      {
        w.WritePoint(new ImagePoint(count++, v));
      }

      if (!myIsFirst)
      {
        myWriter.Write(", ");
      }
      else
      {
        myIsFirst = false;
      }
      AddFile(w.CloseFile());
    }

    protected override void BeforeFileClosed()
    {
      myWriter.WriteLine(" ;");
      base.BeforeFileClosed();
    }

    public void AddFile(IGnuplotLineFile file)
    {
      myWriter.WriteLine("'{0}' with linespoint title \"{1}\" \\", file.FileName, file.Name);
    }
  }
}