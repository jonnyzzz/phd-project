namespace DSIS.UI.Model
{
  public interface IProgressTick
  {
    void Tick(double size);
    void Action(string action);
  }
}