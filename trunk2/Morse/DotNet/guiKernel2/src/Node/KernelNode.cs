using System;
using System.Text;
using guiKernel2.Actions;
using guiKernel2.Container;
using guiKernel2.src.Node;
using MorseKernel2;

namespace guiKernel2.Node
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

		public ActionWrapper[] GetNextActions()
		{
			return Core.Instance.NextActionFactory.NextAction(this);
		}

		public ActionWrapper[] GetNextActionsAfter(ActionWrapper[] path)
		{
			return Core.Instance.NextActionFactory.NextAction(this, path);
		}


		public ResultSet Results
		{
			get
			{
				return results;
			}
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
			switch(results.Length)
			{
				case 0:
					builder.Append("Empty Node");
					break;
				case 1:
					builder.Append("Single Node");
					break;
				default:
					builder.Append("Multiple Node");
					break;
			}

			builder.Append(" {");

			for (int i = 0; i < results.Length; i++ )
			{
				IResult result = results[i];
				if (result is IGraphResult)
				{
					IGraphInfo info = ((IGraphResult)result).GetGraphInfo(); 
					builder.AppendFormat("Graph [ Nodes = {0}, Edges = {1} ]", info.GetNodes(), info.GetEdges());
				} else
				{
					builder.Append("Unknown Result");
				}
				if (i+1 < results.Length)
				{
					builder.Append(", ");
				}
			}

			builder.Append(" }");

			return builder.ToString();

		}
	}
}
