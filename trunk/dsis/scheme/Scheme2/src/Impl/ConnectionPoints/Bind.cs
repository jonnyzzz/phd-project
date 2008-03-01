using System;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Impl.ConnectionPoints
{
  public static class Bind
  {
    public static void BindPoints<TInput,TOutput>(IInputConnectionPoint<TInput> input, IOutputConnectionPoint<TOutput> output)
    {
      if (typeof(TInput) == typeof(TOutput))
        ((IOutputConnectionPoint<TInput>)output).OnDataReady += input.DataReady;
      else if (typeof(TInput).IsAssignableFrom(typeof(TOutput)))
        output.OnDataReady += delegate(TOutput q) { input.DataReady((TInput)(object)q); };
      else
        throw new ArgumentException("Failed to bing output of type " + typeof(TOutput).FullName + " to input of type " +
                                    typeof(TInput).FullName);
    }
  }
}