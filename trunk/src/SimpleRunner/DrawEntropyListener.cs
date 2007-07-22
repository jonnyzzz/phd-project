using System;
using System.Collections.Generic;
using System.IO;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyListener<T, Q> : ProvideExternalListenerBase<T, Q, IDrawEntropyImageListener>, IComputeEntropyListener, IComputationPathListener
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private Dictionary<int, double[]> mySeries = new Dictionary<int, double[]>();
    private int myStepNumber = 0;
    private int myCounputation = 0;
    private string myPath;
    private string myTitle;


    public IEnumerable<Pair<string, Action<string>>> FormatPath
    {
      get { yield return new Pair<string, Action<string>>("{0}", delegate(string path) { myPath = path; }); }
    }

    public void ComputationTitle(string title)
    {
      myTitle = title;
    }

    public override void ComputationStarted(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      mySeries = new Dictionary<int, double[]>();
      myStepNumber = 0;
      myCounputation++;
    }


    public override void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {
      myStepNumber++;
    }

    private string CreateFileName(string ext)
    {
      string path = myPath + "/entropy/image_" + myCounputation + ext;
      string dir = Path.GetDirectoryName(path);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);
      return path;
    }

    private GnuplotScriptParameters CreateGnuplotParams(string image)
    {
      GnuplotScriptParameters ps = new GnuplotScriptParameters(image, "Entropy for " + myTitle);
      ps.ShowKeyHistory = true;
      return ps;
    }
    
    public override void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                             AbstractImageBuilderContext<Q> cx)
    {
      string image = CreateFileName(".png");

      LinesScriptGen gen = new LinesScriptGen(CreateFileName(".pnuplot"), CreateGnuplotParams(image));
      foreach (KeyValuePair<int, double[]> pair in mySeries)
      {
        gen.AddSeria(pair.Key.ToString(), pair.Value);
      }
      gen.Finish();

      GnuplotDrawer.GnuplotDrawer dw = new GnuplotDrawer.GnuplotDrawer();
      dw.DrawImage(gen);

      FireListeners(delegate(IDrawEntropyImageListener obj) { obj.EntropyImageAdded(image); });
    }

    public void OnComputeEntropyStarted()
    {
    }

    public void OnComputeEntropyFinished(double[] value)
    {
      mySeries[myStepNumber] = value;
    }
  }
}