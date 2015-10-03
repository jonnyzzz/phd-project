namespace DSIS.Core.Ioc.Ex
{
  [ComponentInterface]
  public interface ICommandLine
  {
    string[] Args { get; }
  }
}