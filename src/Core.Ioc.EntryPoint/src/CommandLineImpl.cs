using EugenePetrenko.Shared.Core.Ioc.Ex;

namespace EugenePetrenko.Core.Ioc.EntryPoint
{
  public class CommandLineImpl : ICommandLine
  {
    public CommandLineImpl(string[] args)
    {
      Args = args;
    }

    public string[] Args { get; private set; }
  }
}