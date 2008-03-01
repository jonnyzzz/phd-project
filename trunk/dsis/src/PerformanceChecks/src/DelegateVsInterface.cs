using NUnit.Framework;

namespace DSIS.PerformanceChecks
{
  [TestFixture]
  public class DelegateVsInterface : PerformanceBase
  {
    public interface IFoo
    {
      void CallIt(object o);
    }

    public class FooImpl : IFoo
    {
      private int j = 0;
      public void CallIt(object o)
      {
        j++;
      }
    }

    public delegate void CallItD(object o);

    [Test]
    public void Test_Pefomance()
    {
      IFoo foo = new FooImpl();
      CallItD dcc = new FooImpl().CallIt;
      int c = 0;
      CallItD ano = delegate { c++; };

      int MAX = 100000000;
      DoAction("IFoo", delegate
                         {
                           for (int i = 0; i < MAX; i++)
                           {
                             foo.CallIt(new object());
                           }
                         });
      DoAction("Delegate", delegate
                             {
                               for (int i = 0; i < MAX; i++)
                               {
                                 dcc(new object());
                               }
                             });

      DoAction("Delegate Ano", delegate
                             {
                               for (int i = 0; i < MAX; i++)
                               {
                                 ano(new object());
                               }
                             });

      DoAction("IFoo null", delegate
                              {
                                for (int i = 0; i < MAX; i++)
                                {
                                  foo.CallIt(null);
                                }
                              });
      DoAction("Delegate null", delegate
                                  {
                                    for (int i = 0; i < MAX; i++)
                                    {
                                      dcc(null);
                                    }
                                  });

      DoAction("Delegate ano null", delegate
                                  {
                                    for (int i = 0; i < MAX; i++)
                                    {
                                      ano(null);
                                    }
                                  });
      
      EventHost ev = new EventHost();
      ev.F += ano;
      DoAction("Delegate event null", delegate
                                  {
                                    for (int i = 0; i < MAX; i++)
                                    {
                                      ev.Fire(null);
                                    }
                                  });
      DoAction("Delegate event", delegate
                                  {
                                    for (int i = 0; i < MAX; i++)
                                    {
                                      ev.Fire(new object());
                                    }
                                  });
    }
    
    public class EventHost
    {
      public event CallItD F;

      public void Fire(object o)
      {
        F(o);
      }
    }

    private static void DoTest(IFoo foo, CallItD dcc, CallItD ano)
    {
     
    }
  }
}