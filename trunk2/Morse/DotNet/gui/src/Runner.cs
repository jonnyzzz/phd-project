using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using gui.Attributes;
using gui.Forms;
using gui.Logger;
using gui.Resource;
using gui.src.Tree.Node.ActionAllocator;
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
		static void Main(string[] args) 
		{	
            AttributeProcessor.InitializeStaticAttribute(Assembly.GetExecutingAssembly());
            if (args.Length == 1) 
            {
                Resources.SetBasePath(args[0]);
            } else if (args.Length == 2)
            {
                Resources.SetBasePath(args[0], args[1]);
            } else {
                try 
                {
                    Resources.SetBasePath(Application.StartupPath);
                } catch (Exception)
                {
                    try
                    {
                        Resources.SetBasePath( Directory.GetCurrentDirectory());
                    } catch (Exception ee)
                    {
                        Log.LogException(typeof(Runner),ee, "Unable to find any config files");
                    }
                }
            }

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
            Log.LogMessage(this, "Registering global evetns...");
            kernel.InternalException += new IKernelEvents_InternalExceptionEventHandler(interalKernellException);
            kernel.newComputationResult += new IKernelEvents_newComputationResultEventHandler(kernel_newComputationResult);
            kernel.newKernelNode += new IKernelEvents_newKernelNodeEventHandler(kernel_newKernelNode);
            kernel.noChilds += new IKernelEvents_noChildsEventHandler(kernel_noChilds);
            kernel.noImplementation += new IKernelEvents_noImplementationEventHandler(kernel_noImplementation);
        }

        private void unregisterEvents()
        {
            Log.LogMessage(this, "Unregistering global events...");
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
		    DynamicActionNodeTest.Instance.UnRegisterAll();
            DynamicResultTest.Instance.UnRegisterAll();
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
			Log.LogMessage(this, "DLL Exception :" + message);
        }

        private void kernel_newComputationResult(IKernelNode nodeParent, IComputationResult result)
        {
            Log.LogMessage(this, "NewComputationResult");
            computationForm.OnNewComputationResult(nodeParent, result);
        }

        private void kernel_newKernelNode(IKernelNode nodeParent, IKernelNode node)
        {
            Log.LogMessage(this, "E: New kernell Node");
            computationForm.OnNewNode(nodeParent, node);
        }

        private void kernel_noChilds(IKernelNode nodeParent)
        {
            Log.LogMessage(this, "E: No Childs");
            computationForm.noChilds(nodeParent);
        }

        private void kernel_noImplementation(IKernelNode nodeParent)
        {
            Log.LogMessage(this, "E: Not implemented");
            computationForm.noImplementation(nodeParent);
        }
    }
}
