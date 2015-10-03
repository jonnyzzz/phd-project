using System.IO;
using EugenePetrenko.Gui2.Actions.Constraints;
using EugenePetrenko.Gui2.Kernell2;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot;

namespace EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlotGen
{
  /// <summary>
  /// Summary description for GnuPlotGenAction.
  /// </summary>
  public class GnuPlotGenAction : IAction, IGnuPlotScriptGenParameters
  {
    private IGnuPlotGenActionParameters parameters = null;
    private GraphInfoPresenter presenter = new GraphInfoPresenter();

    public void SetActionParameters(IParameters parameters)
    {
      this.parameters = (IGnuPlotGenActionParameters) parameters;
    }

    public void SetProgressBarInfo(IProgressBarInfo pinfo)
    {
    }

    public bool CanDo(IResultSet result)
    {
      return
        new DefaultConstraint(typeof (IResultMetadata), typeof (IGraphResult)).Match(ResultSet.FromResultSet(result));
    }

    public IResultSet Do(IResultSet input)
    {
      ResultSet result = ResultSet.FromResultSet(input);
      int dim = ((IGraphResult) result[0]).GetGraphInfo().GetDimension();
      GnuPlotTemplate template = GnuPlotTemplate.Create(dim, true);
      GnuPlotScriptGen scriptGen = new GnuPlotScriptGen(template, this);

      using (TextWriter param = File.CreateText(Path.Combine(parameters.GlobalPath, parameters.ParametersFile)))
      {
        int cnt = 0;
        foreach (IResult aRes in result.ToResults)
        {
          IGraphResult graphResult = (IGraphResult) aRes;
          string pointsFile = Path.Combine(parameters.GlobalPath, string.Format(parameters.PointFileFormat, cnt++));
          graphResult.SaveText(pointsFile);

          scriptGen.AddFile(pointsFile, presenter.PresentToLogFile(graphResult), parameters.ShowStyle(aRes));
          param.WriteLine(presenter.PresentToLogFile(graphResult));
        }
      }

      using (TextWriter tw = File.CreateText(GnuPlotName))
      {
        tw.WriteLine(scriptGen.Generate());
      }

      return new EmptyResultSet();
    }

    public bool NeedWriteFile
    {
      get { return true; }
    }

    public bool NeedShow
    {
      get { return false; }
    }

    public string GnuPlotName
    {
      get { return Path.Combine(parameters.GlobalPath, parameters.GnuPlotFile); }
    }

    public string FileName
    {
      get { return Path.Combine(parameters.GlobalPath, parameters.OutputFile); }
    }

    public string PlotTitle
    {
      get { return parameters.Title; }
    }

    public int Width
    {
      get { return parameters.Width; }
    }

    public int Height
    {
      get { return parameters.Height; }
    }

    public bool ShowHistory
    {
      get { return parameters.ShowHistory; }
    }

    public bool ShowBoxes
    {
      get { return false; }
    }

    public string ShowStyle(IResult result)
    {
      return "dots";
    }
  }
}