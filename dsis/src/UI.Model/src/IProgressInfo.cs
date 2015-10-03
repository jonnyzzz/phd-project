namespace DSIS.UI.Model
{
  public interface IProgressInfo
  {
    IProgressCounter SubProgress(string name, double units);
  }
}