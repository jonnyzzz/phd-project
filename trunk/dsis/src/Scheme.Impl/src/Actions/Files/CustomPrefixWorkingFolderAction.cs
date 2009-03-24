using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class CustomPrefixWorkingFolderAction : PrefixWorkingFolderAction
  {
    private readonly string myPrefix;

    public CustomPrefixWorkingFolderAction(string prefix)
    {
      myPrefix = prefix;
    }

    protected override string Prefix(Context ctx)
    {
      return myPrefix;
    }
  }
}