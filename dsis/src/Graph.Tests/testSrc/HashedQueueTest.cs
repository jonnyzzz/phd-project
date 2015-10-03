using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph
{
  [TestFixture]
  public class HashedQueueTest
  {
    [Test]
    public void Test_01()
    {
      HashedQueue<int> queue = new HashedQueue<int>();
      queue.Enqueue(1);
      queue.Enqueue(2);
      queue.Enqueue(1);
      queue.Enqueue(3);

      Assert.AreEqual(1,queue.Dequeue());
      Assert.AreEqual(2,queue.Dequeue());
      Assert.AreEqual(3,queue.Dequeue());      
    }
    
    [Test]
    public void Test_02()
    {
      HashedQueue<int> queue = new HashedQueue<int>();
      queue.Enqueue(1);
      queue.Enqueue(2);
      queue.Enqueue(1);
      queue.Enqueue(3);

      Assert.AreEqual(1,queue.Dequeue());
      queue.Enqueue(1);
      Assert.AreEqual(2,queue.Dequeue());
      Assert.AreEqual(3,queue.Dequeue());      

      Assert.AreEqual(1,queue.Dequeue());      
    }
    
  }
}