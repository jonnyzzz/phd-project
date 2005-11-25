using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace Eugene.Petrenko.Gui2.MethodComparer.Parameters
{
    public abstract class MethodParametersBase
    {
        public ResultSet InitialResultSet
        {
            get { return new KernelDocument(GetSystemFunction()).CreateInitialResultSet(); }
        }

        public abstract Function GetSystemFunction();
    }
}