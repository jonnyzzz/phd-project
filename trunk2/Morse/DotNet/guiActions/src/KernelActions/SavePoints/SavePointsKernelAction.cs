using System;
using System.IO;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.KernelActions.SavePoints
{
	/// <summary>
	/// Summary description for SavePointsKernelAction.
	/// </summary>
	public class SavePointsKernelAction : IAction
	{
		public void SetActionParameters(IParameters parameters)
		{
			if (! (parameters is ISavePointsParameters )) throw new ArgumentException();

			this.parameters = (ISavePointsParameters)parameters;

			string path = this.parameters.FilePath;
			if (!Directory.Exists(Path.GetDirectoryName(path))) throw new ArgumentException("File does not exists");
		}

		private ISavePointsParameters parameters = null;

		private IProgressBarInfo progressbarinfo;

		public SavePointsKernelAction()
		{
		}

		public void SetProgressBarInfo(IProgressBarInfo pinfo)
		{
			progressbarinfo = pinfo;
		}

		public bool CanDo(IResultSet result)
		{
			ResultSet resultSet = ResultSet.FromResultSet(result);
			MorseKernel2.IResult[] resultsArray = resultSet.ToResults;
			if (resultsArray.Length != 1 ) return false;
			foreach (MorseKernel2.IResult toResult in resultsArray)
			{
				if (!(toResult is IGraphResult)) return false;
			}
			return true;
		}

		public IResultSet Do(IResultSet input)
		{
			if (! CanDo(input)) throw new ArgumentException();
			ResultSet results = ResultSet.FromResultSet(input);
			MorseKernel2.IResult[] aresults = results.ToResults;
			IGraphResult result = (IGraphResult)aresults[0];

			result.SaveText(parameters.FilePath);

			return ResultSet.Empty().ToResultSet;
		}
	}
}
