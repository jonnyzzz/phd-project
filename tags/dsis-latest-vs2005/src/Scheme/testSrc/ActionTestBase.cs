using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DSIS.Scheme.Ctx;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Scheme.testSrc
{
  public class ActionTestBase
  {
    private string myData;

    [SetUp]
    public virtual void SetUp()
    {
      Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
      Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
      myData = "";
    }

    public void AssertData(string data)
    {
      Assert.AreEqual(data, myData);
    }

    protected ISimpleAction Create(string name)
    {
      return new Mock(name, this);
    }

    protected class Mock : ISimpleAction
    {
      private readonly string myName;
      private readonly ActionTestBase myInstance;

      public Mock(string name, ActionTestBase instance)
      {
        myName = name;
        myInstance = instance;
      }

      public override string ToString()
      {
        return myName;
      }

      public ICollection<ContextMissmatch> Compatible(Context ctx)
      {
        return EmptyArray<ContextMissmatch>.Instance;
      }

      public Context Apply(Context ctx)
      {
        myInstance.myData += "|" + myName + "|";
        Context context = new Context();
        context.Set(new Key<string>(myName), myName);
        return context;
      }
    }
  }
}