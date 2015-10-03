using EugenePetrenko.Gui2.Actions.KernelActions.SavePoints;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.SavePoints
{
  /// <summary>
  /// Summary description for SavePointsParametersImpl.
  /// </summary>
  public class SavePointsParametersImpl : ISavePointsParameters
  {
    private string fileName;

    public SavePointsParametersImpl(string fileName)
    {
      this.fileName = fileName;
    }

    public string FilePath
    {
      get { return fileName; }
    }
  }
}