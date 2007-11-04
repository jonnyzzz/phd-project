using DSIS.Graph.Entropy.Impl;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class EigenEvaluatorImplTest
  {

    [Test]
    public void Test_01()
    {
      new EntropyEvaluatorImpl();            
    }    


    private class EntropyEvaluatorImpl : EntropyEvaluatorImpl<IntegerCoordinate>
    {
      public EntropyEvaluatorImpl() : base(EntropyLoopWeights.CONST)
      {
      }
    }
  }
}