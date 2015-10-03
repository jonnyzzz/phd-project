namespace DSIS.Utils
{
  public interface ITempFileFactory
  {
    string NewFile(string prefix);

    ITempFileFactory ApplyPrefix(string before, string after);
  }
}