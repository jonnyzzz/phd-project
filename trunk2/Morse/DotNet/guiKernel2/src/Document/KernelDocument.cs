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
		private Function function;
		private IKernell kernell;

		public KernelDocument(Function function)
		{
			Core.Instance.SetKernelDocument(this);

			this.function = function;

			
			CKernellImplClass kernellClass = new CKernellImplClass();

			IWritableKernell wKernell = kernellClass as IWritableKernell;

			wKernell.SetFunction(this.function.IFunction);

			kernell = wKernell as IKernell;
			
		}


		public Function Function
		{
			get { return function; }
		}

		public KernelNode CreateInitialNode()
		{
			return new KernelNode(ResultSet.FromResultSet(kernell.CreateInitialResultSet()));
		}
	}
}
