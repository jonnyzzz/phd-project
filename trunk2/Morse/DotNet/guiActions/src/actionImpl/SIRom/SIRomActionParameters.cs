using System;
using guiActions.Parameters;
using guiKernel2.Container;
using MorseKernel2;

namespace guiActions.actionImpl.SIRom
{
	/// <summary>
	/// Summary description for SIRomActionParameters.
	/// </summary>
	public class SIRomActionParameters : ParametersControl
	{
		public SIRomActionParameters()
		{
		}

		protected override IParameters SubmitDataInternal()
		{
			return new SIRomActionParametersImpl(Core.Instance.KernelDocument.Function);			
		}

		public override string BoxCaption
		{
			get { return "SIRom parameters"; }
		}

		public override bool NeedShowForm
		{
			get { return false; }
		}
	}
}
