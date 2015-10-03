using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Core.Visualization;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotPointsFileReader
  {
    private readonly string myFile;

    public GnuplotPointsFileReader(string file)
    {
      myFile = file;
    }

    public IEnumerable<ImagePoint> Read()
    {
      using (TextReader tw = File.OpenText(myFile))
      {
        string line;
        while ((line = tw.ReadLine()) != null)
        {
          string[] digs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
          yield return new ImagePoint(Parse(digs));
        }
      }
    }

    private static double[] Parse(string[] data)
    {
      double[] result = new double[data.Length];
      for(int i=0; i<data.Length; i++)
      {
        result[i] = double.Parse(data[i], CultureInfo.GetCultureInfo("en-us"));
      }
      return result;
    }

  }
}