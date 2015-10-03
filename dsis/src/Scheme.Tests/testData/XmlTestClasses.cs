using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Tests.testData
{
  public abstract class FakeAction : IAction
  {
    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    public Context Apply(Context ctx)
    {
      var r = new Context();
      r.AddAll(ctx);
      return r;
    }
  }

  public class A : FakeAction {     }
  public class B : FakeAction {     }
  public class D : FakeAction {     }
  public class C : FakeAction
  {
    private readonly IAction myA;

    public C(IAction a)
    {
      myA = a;
    }

    public override string ToString()
    {
      return "C:" + string.Join("\n", myA.ToString().Split("\n".ToCharArray()).Map(x=>"     " + x).ToArray())
        ;
    }
  }
}