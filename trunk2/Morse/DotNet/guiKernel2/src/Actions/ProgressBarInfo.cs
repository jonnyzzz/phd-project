using System;
using guiKernel2.Actions;
using MorseKernel2;

namespace guiKernel2.src.Actions
{
	/// <summary>
	/// Summary description for ProgressBar.
	/// </summary>
	/// 
	public delegate void ProgressBarTick();
	public delegate void ProgressBarNewTask(string caption);
	public delegate void ProgressBarNewLength(int length);
	public delegate void ProgressBarFinish();

	public class ProgressBarInfo 
	{
		public event ProgressBarTick Tick;
		public event ProgressBarNewTask NewTask;
		public event ProgressBarFinish TaskFinish;
		public event ProgressBarNewLength NewLength;
	
		public IProgressBarInfo GetProgressBarInfo(ActionWrapper actionWrapper)
		{
			if (NewTask != null)
			{
				NewTask(actionWrapper.ActionName);
			}
			
			ProgressBarInfoImpl info = new ProgressBarInfoImpl(this);
			if (NewLength != null)
			{
				NewLength(info.Length());
			}
			return info;
		}

		private class ProgressBarInfoImpl : IProgressBarInfo
		{
			ProgressBarInfo instance;

			public ProgressBarInfoImpl(ProgressBarInfo instance)
			{
				this.instance = instance;
			}
			
			public void Finish()
			{
				if (instance.TaskFinish != null)
				{
					instance.TaskFinish();
				}
			}
			public int Length()
			{
				return 1>>16;
			}

			public void Next()
			{
				if (instance.Tick != null)
				{
					instance.Tick();
				}
			}

			public bool NeedStop()
			{
				return false;
			}

			public void Start()
			{
				if (instance.Tick != null)
				{
					instance.Tick();
				}
			}
		}
	}
}
