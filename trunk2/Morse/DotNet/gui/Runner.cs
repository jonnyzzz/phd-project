using System;
using System.Windows.Forms;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for Runner.
	/// </summary>
	/// 

	public class Runner
	{
		
		private ComputationForm computationForm;
		private CKernel kernel;

		public static CKernel Kernel 
		{
			get
			{
				return Instance.kernel;
			}
		}

		public static ComputationForm ComputationForm
		{
			get
			{
				return Instance.computationForm;
			}
		}

		
		[STAThread]
		static void Main() 
		{		
			new Runner();			
		}


		IKernelEvents_InternalExceptionEventHandler p;

		public Runner()
		{	
			instance = this;
			Application.ApplicationExit +=new EventHandler(OnApplicationExit);

			kernel = new CKernelClass();
			
			kernel.InternalException += p = new IKernelEvents_InternalExceptionEventHandler(interalKernellException);

			computationForm = new ComputationForm();

			Application.Run(computationForm);
		
			//Application.Run(new Visualization3D(true));
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			instance = null;
			kernel.InternalException -= p;
		}


		private static Runner instance;
		public static Runner Instance 
		{
			get 
			{
				return instance;
			}
		}

		private void interalKernellException(string message)
		{
			Console.Out.WriteLine("DLL Exception :" + message);
		}
	}
}
