using System;

namespace DSIS.SimpleRunner.Actions
{
  public class OperationData
  {
    public readonly string Operation;
    public readonly DateTime StartTime = DateTime.Now;

    public OperationData(string operation)
    {
      Operation = operation;
    }

    public string TotalTime
    {
      get { return (DateTime.Now - StartTime).TotalMilliseconds.ToString(); }
    }
  }
}