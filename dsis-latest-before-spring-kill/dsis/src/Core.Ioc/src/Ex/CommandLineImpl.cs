namespace DSIS.Core.Ioc.Ex
{
  public class CommandLineImpl : ICommandLine
  {
    public CommandLineImpl(string[] args)
    {
      Args = args;
    }

    public string[] Args { get; private set;}
  }
}