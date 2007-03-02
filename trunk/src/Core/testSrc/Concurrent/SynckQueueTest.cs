/*
 * Created by: 
 * Created: 2 марта 2007 г.
 */

using System.Threading;
using NUnit.Framework;

namespace DSIS.Core.Concurrent
{
  [TestFixture]
  public class SynckQueueTest
  {
    private SynchQueue<int> myQueue;

    [SetUp]
    public void SetUp()
    {
      myQueue = new SynchQueue<int>();
    }


    [Test]
    public void Test_01()
    {
      Assert.AreEqual(default(int), myQueue.Dequeue());
    }

    [Test]
    public void Test_02()
    {
      myQueue.Enqueue(6);
      Assert.AreEqual(6, myQueue.Dequeue());
      Assert.AreEqual(default(int), myQueue.Dequeue());
    }

    [Test]
    public void Test_03()
    {
      myQueue.Enqueue(5);
      myQueue.Enqueue(6);
      myQueue.Enqueue(7);

      Assert.AreEqual(5, myQueue.Dequeue());
      Assert.AreEqual(6, myQueue.Dequeue());
      Assert.AreEqual(7, myQueue.Dequeue());
      Assert.AreEqual(default(int), myQueue.Dequeue());
    }


    [Test, Ignore]
    public void Test_04()
    {
      
      AutoResetEvent ee = new AutoResetEvent(false);
      Thread cons = new Thread((ThreadStart)delegate
                                              {
                                                myQueue.Enqueue(5);
                                                myQueue.Enqueue(6);
                                                myQueue.Enqueue(7);
                                                ee.WaitOne();
                                                myQueue.Enqueue(10);
                                              });
      cons.IsBackground = true;

      Assert.AreEqual(default(int), myQueue.Dequeue());

      cons.Start();

      myQueue.WaitData();      
      Assert.AreEqual(5, myQueue.Dequeue());

      myQueue.WaitData();
      Assert.AreEqual(6, myQueue.Dequeue());

      myQueue.WaitData();
      Assert.AreEqual(7, myQueue.Dequeue());

      Assert.AreEqual(0, myQueue.Dequeue());

      ee.Set();

      myQueue.WaitData();
      Assert.AreEqual(10, myQueue.Dequeue());

      Assert.AreEqual(0, myQueue.Dequeue());
    }

  }
}