using System;
using guiActions.KernelActions.SavePoints;

namespace guiActions.src.actionImpl.SavePoints
{
	/// <summary>
	/// Summary description for SavePointsParametersImpl.
	/// </summary>
	public class SavePointsParametersImpl : ISavePointsParameters
	{
		private string fileName;

		public SavePointsParametersImpl(string fileName)
		{
			this.fileName = fileName;
		}

		public string FilePath
		{
			get { return fileName; }
		}

	}
}
