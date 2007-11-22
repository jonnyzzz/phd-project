using EugenePetrenko.Gui2.Controls.Control;

namespace EugenePetrenko.Gui2.Controls.Grid
{
  /// <summary>
  /// Summary description for ExGridException.
  /// </summary>
  public class ExGridException : ControlException
  {
    public ExGridException(string message) : base(message)
    {
      errorDescShort = Message;
    }

    public ExGridException(string template, params object[] pars) : base(string.Format(template, pars))
    {
      errorDescShort = Message;
    }

    private string errorDescShort;

    public override string ErrorDescription
    {
      get { return errorDescShort; }
    }

    public override string ErrorDescriptionShort
    {
      get { return errorDescShort; }
    }
  }

  public class ExGridCellException : ExGridException
  {
    private readonly int index;
    private readonly string messageTemplate;

    /// <summary>
    /// template should contain {0} position to 
    /// substitute error position.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="template"></param>
    public ExGridCellException(int index, string template) : base(template)
    {
      messageTemplate = template;
      this.index = index;
    }

    public string MessageTemplate
    {
      get { return messageTemplate; }
    }

    public int Index
    {
      get { return index; }
    }
  }
}