using System.Text;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Node
{
  /// <summary>
  /// Summary description for Node.
  /// </summary>
  public class KernelNode
  {
    private ResultSet results;

    public KernelNode(ResultSet results)
    {
      this.results = results;
    }

    public ResultSet Results
    {
      get { return results; }
    }

    private string caption = null;

    public string Caption
    {
      get
      {
        if (caption == null)
        {
          caption = CreateCaption();
        }
        return caption;
      }
    }

    private string CreateCaption()
    {
      IResult[] results = Results.ToResults;
      StringBuilder builder = new StringBuilder();
      switch (results.Length)
      {
        case 0:
          builder.Append("Empty Result");
          break;
        case 1:
          builder.Append("Single Result");
          break;
        default:
          builder.Append("Multiple Result");
          break;
      }

      builder.Append(" {");

      for (int i = 0; i < results.Length; i++)
      {
        builder.Append(GetResultCaption(results[i], false));
        if (i + 1 < results.Length)
        {
          builder.Append(", ");
        }
      }

      builder.Append(" }");

      return builder.ToString();
    }

    public static string GetResultCaption(IResult result, bool showCellSizes)
    {
      StringBuilder builder = new StringBuilder();
      if (result is IGraphResult)
      {
        IGraphInfo info = ((IGraphResult) result).GetGraphInfo();
        builder.AppendFormat("Graph [ Nodes = {0}, Edges = {1} ]", info.GetNodes(), info.GetEdges());
        if (showCellSizes)
        {
          builder.Append(" ( ");
          for (int i = 0; i < info.GetDimension(); i++)
          {
            builder.AppendFormat("{0}", info.GetGridSize(i));
            if (i < info.GetDimension() - 1) builder.Append(", ");
          }
          builder.Append(" ) ");
        }
      }
      else if (result is ISpectrumResult)
      {
        ISpectrumResult spectrumResult = (ISpectrumResult) result;
        builder.AppendFormat("Spectrum [{0}, {1}]", spectrumResult.GetLowerBound(), spectrumResult.GetUpperBound());
      }
      else
      {
        builder.Append("Unknown Result");
      }
      return builder.ToString();
    }
  }
}