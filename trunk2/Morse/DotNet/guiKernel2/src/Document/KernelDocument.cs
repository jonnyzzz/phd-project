using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiKernel2.Document
{
	/// <summary>
	/// Summary description for Document.
	/// </summary>
	public class KernelDocument
	{
		private IFunction function;
		private IKernell kernell;

		public KernelDocument(Function function)
		{
			Core.Instance.SetKernelDocument(this);
			this.function = function.IFunction;
			CKernellImplClass kernellClass = new CKernellImplClass();
			IWritableKernell wKernell = kernellClass;
			wKernell.SetFunction(this.function);
			kernell = kernellClass;
		}


		public IFunction Function
		{
			get { return function; }
		}

		public KernelNode CreateInitialNode()
		{
			return new KernelNode(kernell.CreateInitialResult());
		}
	}
}
