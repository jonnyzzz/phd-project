using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Visualization;

namespace DSIS.GnuplotDrawer
{
  public class LinesScriptGen : PngWriterBase, IGnuplotLineScriptGen
  {
    private readonly Dictionary<string, int> myCriteriaToCode = new Dictionary<string, int>();
    private bool myIsFirst = true;
    private readonly Func<string, string> CreateCriteriaFileName;

    public LinesScriptGen(string file, GnuplotScriptParameters ps) : base(file, ps)
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
            return Path.GetFullPath(file + v + ".dat");
          };
    }

    public string AddSeria(string name, IEnumerable<double> values)
    {
      string file = CreateCriteriaFileName(name);
      var w = new LinePointsFile(file, 2, name);
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

      return file;
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