using System;
using System.Collections.Generic;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class CurveLengthSlot
  {
    private readonly List<Data> myData = new List<Data>();

    public void AddData(int step, long count, double data)
    {
      myData.Add(new Data(step, count, data));
    }

    public void EnumerateData(Action<int, long, double> fun)
    {
      myData.Sort((a,b)=>a.Step.CompareTo(b.Step));
      foreach (var data in myData)
      {
        fun(data.Step, data.Count, data.Length);
      }
    }

    public void Clear()
    {
      myData.Clear();
    }

    private  class Data
    {
      public readonly double Length;
      public readonly long Count;
      public readonly int Step;

      public Data(int step, long count, double length)
      {
        Step = step;
        Length = length;
        Count = count;
      }
    }

  }
}