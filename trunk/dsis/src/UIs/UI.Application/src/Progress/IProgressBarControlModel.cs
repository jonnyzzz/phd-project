namespace DSIS.UI.Application.Progress
{
  public interface IProgressBarControlModel
  {
    bool Disabled { get; }

    int Value { get; }
    int Maximum { get; }
    string Text { get; }
    void Interrupt();
  }
}