using System;
using MorseKernel2;

namespace guiActions.actionImpl.Projector
{
	/// <summary>
	/// Summary description for ProjectorParametersImpl.
	/// </summary>
	public class ProjectorParametersImpl : IProjectActionParameters
	{
		private int[] devisor;

		public ProjectorParametersImpl(int[] data) 
		{
			this.devisor = data;
		}

		public int GetDevisor(int index) 
		{
			return devisor[index];
		}
		
	}
}
