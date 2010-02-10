using System;
using guiKernel2.Actions;
using guiKernel2.src.ActionFactory;
using MorseKernel2;

namespace guiKernel2.ActionImpl
{
	/// <summary>
	/// Summary description for TarjanAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(ITarjanAction), typeof(ITarjanParameters))]
	public class TarjanActionWrapper : ActionWrapper
	{
		public TarjanActionWrapper(IAction action) : base(action)
		{
		}

		public override string ActionName
		{
			get { return "Tarjan Task"; }
		}

		protected override IParameters Parameters
		{
			get { throw new NotImplementedException(); }
		}

		public override bool isChainLeaf
		{
			get { return true; }
		}
	}
}
