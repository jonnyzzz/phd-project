using System;
using System.Threading;
using NUnit.Framework;

namespace DSIS.Utils.testSrc
{
  [TestFixture]
  public class TimeoutTest
  {
    public delegate void VoidDelegate();

    [Test, ExpectedException(typeof(Exception))]
    public void Test_01()
    {
      DoTestWithTimout(1000, delegate { throw new Exception("aaa"); });
    }


    [Test, ExpectedException(typeof(ThreadAbortException))]
    public void Test_02()
    {
      DoTestWithTimout(10, delegate { while (true) ; });
    }

    public static void DoTestWithTimout(int timeout, VoidDelegate action)
    {
      Exception e = null;
      ManualResetEvent eee = new ManualResetEvent(false);
      Thread thread = new Thread(delegate()
                                   {
                                     try
                                     {
                                       eee.Set();
                                       action();                                       
                                     } catch (Exception ee)
                                     {
                                       e = ee;
                                     }
                                   });
      thread.Name = "test Thread";
      thread.IsBackground = true;
      thread.Start();
      eee.WaitOne();

      if (!thread.Join(timeout))
          thread.Abort();

      thread.Join();

      if (e != null)
        throw e;
    }
  }
}