using System;
using guiKernel2.Document;
using MorseKernel2;

namespace guiActions.actionImpl.SIRom
{
	/// <summary>
	/// Summary description for SIRomActionParametersImpl.
	/// </summary>
	public class SIRomActionParametersImpl : ISIRomActionParameters
	{
		private Function function;

		public SIRomActionParametersImpl(Function function)
		{
			this.function = function;
		}

		public IFunction GetFunction()
		{
			return function.IFunction;
		}
	}
}
