using DSIS.Graph.Morse.JVR;
using NUnit.Framework;

namespace DSIS.Graph.Morse.Tests
{
  [TestFixture]
  public class JVRMethodTest : MorseTestData
  {
    protected override IMorseEvaluator<T> CreateEvaluator<T>(IMorseEvaluatorCost<T> cost, IMorseEvaluatorGraph<T> graph)
    {
      return new JVREvaluator<T>(new JVREvaluatorOptions {Eps = Eps}, graph, cost);
    }
  }
}