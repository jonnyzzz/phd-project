using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DSIS.GnuplotDrawer
{
  public class LinesScriptGen : PngWriterBase, IGnuplotLineScriptGen
  {
    private readonly Dictionary<string, int> myCriteriaToCode = new Dictionary<string, int>();
    private bool myIsFirst = true;

    public LinesScriptGen(string file, GnuplotScriptParameters ps) : base(file, ps)
    {
      myWriter.Write("plot ");
    }

    public string AddSeria(string name, IEnumerable<double> values)
    {
      string file = CreateCriteriaFileName(name);
      using (GnuplotFileWriterBase w = new GnuplotFileWriterBase(file))
      {
        file = w.Filename;
        int count = 0;
        foreach (double v in values)
        {
          w.myWriter.Write(count++);
          w.myWriter.Write(" ");
          w.myWriter.WriteLine(v.ToString("R", CultureInfo.InvariantCulture));
        }
      }

      if (!myIsFirst)
      {
        myWriter.Write(", ");
      } else
      {
        myIsFirst = false;
      }

      AddFile(file, name);
      return file;
    }

    public void AddFile(string file, string title)
    {
      myWriter.WriteLine("'{0}' with linespoint title \"{1}\" \\", file, title);
    }

    private string CreateCriteriaFileName(string name)
    {
      int v;
      if (!myCriteriaToCode.TryGetValue(name, out v))
      {
        v = myCriteriaToCode[name] = myCriteriaToCode.Count + 1;
      }
      return Path.GetFullPath(Filename + v + ".dat");
    }

    public override void Dispose()
    {
      myWriter.WriteLine(" ;");
      base.Dispose();
    }
  }
}