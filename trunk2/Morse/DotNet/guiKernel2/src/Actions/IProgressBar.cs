using System;
using MorseKernel2;

namespace guiKernel2.src.Actions
{
	/// <summary>
	/// Summary description for IProgressBar.
	/// </summary>
	public interface IProgressBar : IProgressBarInfo
	{
		string ActionDescription { get; set;}
	}
}
