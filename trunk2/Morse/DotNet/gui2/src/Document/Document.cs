using gui2.TreeNodes;
using guiKernel2.Document;
using guiKernel2.Node;

namespace gui2.Document
{
	/// <summary>
	/// Summary description for Document.
	/// </summary>
	public class Document
	{
		private KernelDocument kernelDocument;
		private Node rootNode = null;

		public Document(Function function)	
		{			
			kernelDocument = new KernelDocument(function);
			rootNode = new Node(kernelDocument.CreateInitialNode());
		}

		public Document(Function function, Node root)
		{
			kernelDocument = new KernelDocument(function);
			rootNode = root;			
		}

		public KernelDocument KernelDocument
		{
			get { return kernelDocument; }
			set { kernelDocument = value; }
		}

		public Node RootNode
		{
			get { return rootNode; }
		}


		public void Lock()
		{
			Runner.Runner.Instance.ComputationForm.Lock();
		}

		public void UnLock()
		{
			Runner.Runner.Instance.ComputationForm.Unlock();
		}

	}
}
