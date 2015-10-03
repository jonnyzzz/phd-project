namespace DSIS.Scheme.Impl.Actions.Files
{
  public class ConsoleLogger : Logger
  {
    public override void Write(string text)
    {
      System.Console.Out.WriteLine(text);
    }
  }
}