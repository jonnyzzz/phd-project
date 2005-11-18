using System;
using System.Windows.Forms;
using guiControls.Control;
using MorseKernel2;

namespace guiActions.Parameters
{
	public delegate void ParametersSubmitted(IParameters parameters);

	public class ParametersControl : UserControl, ISubmittable
	{
		//pseudo abstract method
		protected virtual IParameters SubmitDataInternal()
		{
			throw new NotImplementedException("Implement SubmitData in the inheritor class");
		}

		//abstract
		public virtual string BoxCaption
		{
			get
			{
				throw new NotImplementedException("Implement ParametersCaption in the inheritor class");
			}
		}        

		public virtual bool NeedShowForm
		{
			get
			{
				return true;
			}
		}

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