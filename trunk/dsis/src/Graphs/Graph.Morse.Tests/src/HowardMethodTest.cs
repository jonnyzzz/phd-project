using System;
using DSIS.Graph.Morse.Howard;
using NUnit.Framework;

namespace DSIS.Graph.Morse.Tests
{
  [TestFixture]
  public class HowardMethodTest : MorseTestData
  {
    protected override IMorseEvaluator<T> CreateEvaluator<T>(IMorseEvaluatorCost<T> cost, IMorseEvaluatorGraph<T> graph)
    {
      return new HowardEvaluator<T>(new HowardEvaluatorOptions {Eps = Eps}, graph, cost);
    }
  }
}