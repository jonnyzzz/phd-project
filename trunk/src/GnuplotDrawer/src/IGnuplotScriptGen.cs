using System;
using System.Collections.Generic;
using System.IO;

namespace DSIS.GnuplotDrawer
{
  public interface IGnuplotScriptGen
  {
    void AddPointsFile(GnuplotPointsFileWriter file);
    void Dispose();

    string Filename { get; }
  }

  public class MergedGnuplotScriptGen : IGnuplotScriptGen
  {
    private readonly IGnuplotScriptGen myGen;
    private readonly List<GnuplotPointsFileWriter> myFiles = new List<GnuplotPointsFileWriter>();

    public MergedGnuplotScriptGen(IGnuplotScriptGen gen)
    {
      myGen = gen;
    }

    public void AddPointsFile(GnuplotPointsFileWriter file)
    {
      myFiles.Add(file);
    }

    public void Dispose()
    {
      myFiles.Sort(
        delegate(GnuplotPointsFileWriter w1, GnuplotPointsFileWriter w2) {
            return - w1.PointsCount.CompareTo(w2.PointsCount); });

      for (int i = 0; i < Math.Min(100, myFiles.Count); i++ )
        myGen.AddPointsFile(myFiles[i]);

      myGen.Dispose();      
    }    

    public string Filename
    {
      get { return myGen.Filename; }
    }
  }
}