using System;
using EugenePetrenko.Gui2.Actions.ActionImpl.MSSegment.Create;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MSAngle
{
	/// <summary>
	/// Summary description for MSAngleCreationAction.
	/// </summary>
	[ActionMapping(typeof(IMSAngleCreationMethod), typeof (IMSCreationParameters))]
	public class MSAngleCreationAction : MSCreationAction
	{
		public MSAngleCreationAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
		{
		}

		protected override IAction CreateAction()
		{
			return new CMSAngleCreationMethodClass();
		}
	}
}
