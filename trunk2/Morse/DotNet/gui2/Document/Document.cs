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
		private KernelNode rootNode = null;

		public Document(Function function)
		{			
			kernelDocument = new KernelDocument(function);
			rootNode = kernelDocument.CreateInitialNode();
		}

		public KernelDocument KernelDocument
		{
			get { return kernelDocument; }
			set { kernelDocument = value; }
		}

		public Node RootNode
		{
			get { return new Node(rootNode); }			
		}

	}
}
