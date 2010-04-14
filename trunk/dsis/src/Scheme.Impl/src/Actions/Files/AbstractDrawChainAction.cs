using System;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

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
      var folderInfo = GetWorkingFolderInfo(input);
      IGraphStrongComponents<Q> comps = Keys.GetGraphComponents<Q>().Get(input);

      var pw = CreateComponentWriter(folderInfo);
      var files = pw.WriteComponents(system, comps);

      string outputFile = folderInfo.NewFile("chain-recurrent-picture.png");
      var result = new ImageResult(outputFile);

      var gen = GnuplotSriptGen.ScriptGen(
        system.Dimension, folderInfo.ApplyPrefix("chain-recurrent-picture-script.", ""),
        CreateOutputParameters(input, outputFile));

      foreach (var file in files)
      {        
        gen.AddPointsFile(file);
      }

      DrawFromScript(gen.CloseFile());

      FileKeys.ImageKey.Set(output, result);
    }

    protected virtual IComponentPointsWriter CreateComponentWriter(ITempFileFactory folderInfo)
    {
      return new ComponentPointsWriter(folderInfo);
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

    protected abstract ITempFileFactory GetWorkingFolderInfo(IReadOnlyContext input);    
  }
}