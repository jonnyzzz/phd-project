using System;
using MorseKernel2;

namespace guiActions.KernelActions.SavePoints
{
	/// <summary>
	/// Summary description for ISavePointsParameters.
	/// </summary>
	public interface ISavePointsParameters : IParameters
	{
		string FilePath { get; }
	}
}
