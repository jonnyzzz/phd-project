namespace DSIS.Utils
{
  public interface ILogger
  {
    void Write(string text);
    void Write(string text, params object[] data);
  }

  public interface ILoggable
  {
    void Log(ILogger logger);
  }
}
