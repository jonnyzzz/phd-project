namespace EugenePetrenko.Gui2.Controls.Grid
{
    /// <summary>
    /// Summary description for IExGridRow.
    /// </summary>
    public interface IExGridRow
    {
        string this[int index] { get; set; }
        string Caption { get; }
    }

    public interface IExGridHandler
    {
        bool NeedAcceptRowChanged();
    }
}