using System;
using MorseKernel2;

namespace guiKernel2.Actions
{
	/// <summary>
	/// Summary description for IProgressBar.
	/// </summary>
	public interface IProgressBar
	{
		IProgressBarInfo GetProgressBarInfo(ActionWrapper actionWrapper);
	}
}
