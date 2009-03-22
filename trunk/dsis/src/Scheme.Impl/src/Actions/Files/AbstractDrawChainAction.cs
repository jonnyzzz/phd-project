using System;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class AbstractDrawChainAction : IntegerCoordinateSystemActionBase2Ex
  {
    protected override void GetChecks<T, Q>(T system, Action<ContextMissmatchCheck> addCheck)
    {
      addCheck(Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      WorkingFolderInfo folderInfo = GetWorkingFolderInfo(input);
      IGraphStrongComponents<Q> comps = Keys.GetGraphComponents<Q>().Get(input);

      var pw = new ComponentPointsWriter(folderInfo);
      var files = pw.WriteComponents(system, comps);

      string outputFile = folderInfo.CreateFileName("chain-recurrent-picture.png");
      var result = new ImageResult(outputFile);

      var gen = GnuplotSriptGen.ScriptGen(
        system.Dimension,
        folderInfo.CreateFileName("chain-recurrent-picture-script.gnuplot"),
        CreateOutputParameters(input, outputFile));

      foreach (var file in files)
      {        
        gen.AddPointsFile(file);
      }

      DrawFromScript(gen.CloseFile());

      FileKeys.ImageKey.Set(output, result);
    }

    protected virtual GnuplotScriptParameters CreateOutputParameters(IReadOnlyContext context, string outputFile)
    {
      var ps = new GnuplotScriptParameters(outputFile, "");
      if (context.ContainsKey(ImageDimension.KEY))
      {
        var d = ImageDimension.KEY.Get(context);
        ps.Width = d.Width;
        ps.Height = d.Height;
      }
      return ps;
    }

    protected abstract void DrawFromScript(IGnuplotScript gen);

    protected abstract WorkingFolderInfo GetWorkingFolderInfo(IReadOnlyContext input);    
  }
}