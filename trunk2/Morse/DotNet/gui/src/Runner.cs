using System;
using System.Windows.Forms;
using gui.Forms;
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

		public Runner()
		{	
			instance = this;
			Application.ApplicationExit += new EventHandler(OnApplicationExit);

			kernel = new CKernelClass();
			
            registerEvents();			

			computationForm = new ComputationForm();

			Application.Run(computationForm);
		
			//Application.Run(new Visualization3D(true));
		}

        private void registerEvents()
        {
            Console.Out.WriteLine("Registering global evetns...");
            kernel.InternalException += new IKernelEvents_InternalExceptionEventHandler(interalKernellException);
            kernel.newComputationResult += new IKernelEvents_newComputationResultEventHandler(kernel_newComputationResult);
            kernel.newKernelNode += new IKernelEvents_newKernelNodeEventHandler(kernel_newKernelNode);
            kernel.noChilds += new IKernelEvents_noChildsEventHandler(kernel_noChilds);
            kernel.noImplementation += new IKernelEvents_noImplementationEventHandler(kernel_noImplementation);
        }

        private void unregisterEvents()
        {
            Console.Out.WriteLine("Unregistering global events...");
            kernel.InternalException -= new IKernelEvents_InternalExceptionEventHandler(interalKernellException);
            kernel.newComputationResult -= new IKernelEvents_newComputationResultEventHandler(kernel_newComputationResult);
            kernel.newKernelNode -= new IKernelEvents_newKernelNodeEventHandler(kernel_newKernelNode);
            kernel.noChilds -= new IKernelEvents_noChildsEventHandler(kernel_noChilds);
            kernel.noImplementation -= new IKernelEvents_noImplementationEventHandler(kernel_noImplementation);                       
        }


		private void OnApplicationExit(object sender, EventArgs e)
		{
			instance = null;
			unregisterEvents();
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

        private void kernel_newComputationResult(IKernelNode nodeParent, IComputationResult result)
        {
            Console.Out.WriteLine("NewComputationResult");
            computationForm.OnNewComputationResult(nodeParent, result);
        }

        private void kernel_newKernelNode(IKernelNode nodeParent, IKernelNode node)
        {
            computationForm.OnNewNode(nodeParent, node);
        }

        private void kernel_noChilds(IKernelNode nodeParent)
        {
            computationForm.noChilds(nodeParent);
        }

        private void kernel_noImplementation(IKernelNode nodeParent)
        {
            computationForm.noImplementation(nodeParent);
        }
    }
}
