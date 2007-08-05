using System.Collections.Generic;
using DSIS.GnuplotDrawer;

namespace DSIS.SimpleRunner
{
  public abstract class DrawEntropyBase : DrawBase
  {
    private readonly Dictionary<int, double[]> mySeries = new Dictionary<int, double[]>();
    private int myStepNumber = 0;

    protected abstract IEnumerable<LineData> CreateSeria(IDictionary<int, double[]> results);

    private GnuplotScriptParameters CreateGnuplotParams(string image)
    {
      GnuplotScriptParameters ps = new GnuplotScriptParameters(image, "Entropy for " + Title);
      ps.ShowKeyHistory = true;
      return ps;
    }    
    
    public override string DrawImage(string suffix)
    {
      string image = CreateFileName(suffix + ".png");

      LinesScriptGen gen = new LinesScriptGen(CreateFileName(".pnuplot"), CreateGnuplotParams(image));

      foreach (LineData data in CreateSeria(mySeries))
      {
        gen.AddSeria(data.Name, data.Data);
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
   
    protected class LineData
    {
      public readonly string Name;
      public readonly IEnumerable<double> Data;

      public LineData(string name, IEnumerable<double> data)
      {
        Name = name;
        Data = data;
      }
    }
  }
}