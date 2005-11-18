using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Document
{
    /// <summary>
    /// Summary description for Document.
    /// </summary>
    public class KernelDocument
    {
        private Function function;
        private IKernell kernell;
        private string defaultTitle;

        public KernelDocument(Function function)
        {
            Core.Instance.SetKernelDocument(this);

            this.function = function;


            CKernellImplClass kernellClass = new CKernellImplClass();

            IWritableKernell wKernell = kernellClass;

            wKernell.SetFunction(this.function.IFunction);

            kernell = (IKernell) wKernell;
        }

        public string Title
        {
            get { return defaultTitle; }
            set { defaultTitle = value; }
        }

        public Function Function
        {
            get { return function; }
        }

        public KernelNode CreateInitialNode()
        {
            KernelNode node = new KernelNode(ResultSet.FromResultSet(kernell.CreateInitialResultSet()));
            node.GetNextActions();
            return node;
        }
    }
}