using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionImpl
{
    public interface IDisabledActionInterface : IAction
    {
    }

    /// <summary>
    /// Summary description for IDisabledAction.
    /// </summary>
    public interface IDisabledAction // : IAction
    {
        void SetComment(string comment);

        string Comment { get; }
        string Caption { get; }
    }
}