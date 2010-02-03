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
    private readonly Function function;
    private readonly IKernell kernell;

    public KernelDocument(Function function)
    {
      Core.Instance.SetKernelDocument(this);

      this.function = function;

      var kernellClass = new CKernellImplClass();
      IWritableKernell wKernell = kernellClass;

      wKernell.SetFunction(this.function.IFunction);

      kernell = (IKernell) wKernell;
    }

    public string Title { get; set; }

    public Function Function
    {
      get { return function; }
    }

    public KernelNode CreateInitialNode()
    {
      return new KernelNode(CreateInitialResultSet());
    }

    public ResultSet CreateInitialResultSet()
    {
      return ResultSet.FromResultSet(kernell.CreateInitialResultSet());
    }
  }
}