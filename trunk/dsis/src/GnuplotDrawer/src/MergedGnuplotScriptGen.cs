using System;
using System.Collections.Generic;

namespace DSIS.GnuplotDrawer
{
  public class MergedGnuplotScriptGen : IGnuplotScriptGen
  {
    private readonly IGnuplotPhaseScriptGen myGen;
    private readonly List<GnuplotPointsFileWriter> myFiles = new List<GnuplotPointsFileWriter>();

    public MergedGnuplotScriptGen(IGnuplotPhaseScriptGen gen)
    {
      myGen = gen;
    }

    public void AddPointsFile(GnuplotPointsFileWriter file)
    {
      myFiles.Add(file);
    }

    public void Finish()
    {
      myFiles.Sort(
        (w1, w2) => - w1.PointsCount.CompareTo(w2.PointsCount));

      for (int i = 0; i < Math.Min(100, myFiles.Count); i++ )
        myGen.AddPointsFile(myFiles[i]);

      myGen.Finish();      
    }    

    public string Filename
    {
      get { return myGen.Filename; }
    }
  }
}