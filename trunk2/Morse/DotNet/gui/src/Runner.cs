using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using gui.Attributes;
using gui.Forms;
using gui.Logger;
using gui.Resource;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Factory;
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

		
		private static bool isInternal = true;
		public static bool IsInternal
		{
			get { return isInternal; }
		}

		static CommandLineParsers commandLineParsers;


		[STAThread]
		static void Main(string[] args) 
		{	
			try 
			{
				commandLineParsers = new CommandLineParsers(args);
			} catch (CommandLineParseException e)
			{
				Log.LogException(typeof(Runner), e, "Unable to parse command line");
				MessageBox.Show(e.Message, "Wrong parameters");
				return;
			}
			isInternal = commandLineParsers.hasKey("internal");

            Thread.CurrentThread.Name = "MainThread";
            AttributeProcessor.InitializeStaticAttribute(Assembly.GetExecutingAssembly());

			#region initResources
			if (commandLineParsers.hasKey("resources") && commandLineParsers.hasKey("temporary"))
			{
				Resources.SetBasePath(
					commandLineParsers.getValue("resources"), 
					commandLineParsers.getValue("temporary")
					);
			} else if (commandLineParsers.hasKey("resources"))
			{
				Resources.SetBasePath(commandLineParsers.getValue("resources"));
			} else
			{		
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
						MessageBox.Show("Unable to locate program resource files.", "Run failed");
                    }
                }
            }
			#endregion

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

		#region events
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
		#endregion


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

		#region eventHandlers
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
		#endregion
    }
}
