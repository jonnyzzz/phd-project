namespace DSIS.Core.System
{
  public class RenameSystemFormat : RenameSystem
  {
    public RenameSystemFormat(ISystemInfo systemInfo, string newName) : base(systemInfo, string.Format(newName, systemInfo.PresentableName))
    {
    }
  }
}