using DSIS.Graph.Entropy.Impl;
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
      EntropyEvaluatorImpl imp = new EntropyEvaluatorImpl();            
    }    


    private class EntropyEvaluatorImpl : EntropyEvaluatorImpl<IntegerCoordinate>
    {
      
    }
  }
}