using System;
using System.Windows.Forms;
using MorseKernel2;

namespace guiActions.parameters
{
	public delegate void ParametersSubmitted(IParameters parameters);

	public abstract class ParametersControl : Control
	{
		protected abstract IParameters SubmitDataInternal();


		private IParameters cachedParameters = null;
		
		public IParameters CachedParameters
		{
			get { return cachedParameters; }
		}

		public void SubmitData()
		{
			try
			{
				cachedParameters = SubmitDataInternal();
				if (DataSubmitted != null)
				{
					DataSubmitted(CachedParameters);
				}
			} catch (Exception e)
			{
				throw e;
			}			
		}

		public event ParametersSubmitted DataSubmitted;
	}
}