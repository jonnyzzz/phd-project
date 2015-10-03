using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.BoxIterators.Generator;
using NUnit.Framework;

namespace DSIS.PerformanceChecks
{
  [TestFixture]
  public class BoxIteratorGeneratedPerformance : PerformanceBase
  {
    [Test]
    public void Test_01()
    {
      IBoxIterator<int> iterator = BoxIteratorGenerator<int>.GenerateIterator(1);
      DoAction("dim 1", delegate
                          {
                            var l = new List<int[]>();
                            var box = iterator.EnumerateBox(new[] {0}, new[] {100}, new int[1]);
                            l.AddRange(box);
                          }, 1000000);      
    }
    
    [Test]
    public void Test_02()
    {
      IBoxIterator<int> iterator = BoxIteratorGenerator<int>.GenerateIterator(2);
      DoAction("dim 2", delegate
                          {
                            var l = new List<int[]>();
                            IEnumerable<int[]> box = iterator.EnumerateBox(new[] {0,0}, new[] {100,100}, new int[2]);
                            l.AddRange(box);
                          }, 1000000);      
    }
    
  }
}