using System;
using MorseKernel2;

namespace guiActions.actionImpl.MinimalLoopLocalization
{
	/// <summary>
	/// Summary description for MinimalLoopLocalizationParametersImpl.
	/// </summary>
	public class MinimalLoopLocalizationParametersImpl : IMinimalLoopLocalizationParameters
	{
		double[] coordinates;

		public MinimalLoopLocalizationParametersImpl(double[] coordinates)
		{
			this.coordinates = coordinates;
		}

		public double GetCoordinate(int id)
		{
			return coordinates[id];
		}
	}
}
