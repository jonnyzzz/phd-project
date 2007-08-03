using System;
using System.Collections.Generic;
using System.IO;
using DSIS.GnuplotDrawer;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyUtil
  {
    private readonly Dictionary<int, double[]> mySeries = new Dictionary<int, double[]>();    
    private string myTitle;
    private int myStepNumber = 0;
    private string myPath;    

    public string Title
    {
      set { myTitle = value; }
    }

    public Pair<string, Action<string>> FormatPath
    {
      get { return new Pair<string, Action<string>>("{0}", delegate(string path) { myPath = path; }); }
    }

    private string CreateFileName(string ext)
    {
      string path = myPath + "/entropy/image_" + ext;
      string dir = Path.GetDirectoryName(path);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);
      if (File.Exists(path))
        return CreateFileName(".1" + ext);
      return path;
    }

    private static List<double> Scan(Dictionary<int, double[]> ds, int idx)
    {
      List<double> result = new List<double>();
      for(int i = idx; ; i++)
      {
        double[] dl;
        if (!ds.TryGetValue(i, out dl))
          break;
        int k = i - idx;
        if (k >= 0 && k < dl.Length)
          result.Add(dl[i - idx]);
        else
          break;
      }
      return result;
    }

    private GnuplotScriptParameters CreateGnuplotParams(string image)
    {
      GnuplotScriptParameters ps = new GnuplotScriptParameters(image, "Entropy for " + myTitle);
      ps.ShowKeyHistory = true;
      return ps;
    }

    public string DrawImage(string suffix)
    {
      string image = CreateFileName(suffix + ".png");

      LinesScriptGen gen = new LinesScriptGen(CreateFileName(".pnuplot"), CreateGnuplotParams(image));
      foreach (KeyValuePair<int, double[]> pair in mySeries)
      {
        gen.AddSeria(pair.Key.ToString(), Scan(mySeries, pair.Key));
      }
      gen.Finish();

      GnuplotDrawer.GnuplotDrawer dw = new GnuplotDrawer.GnuplotDrawer();
      dw.DrawImage(gen);

      return image;
    }

    public void AppendResult(double[] value)
    {
      mySeries[myStepNumber++] = value;
    }    
  }
}