using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DSIS.Scheme.Ctx;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Scheme.Tests
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

    protected IAction Create<T>(string name, T t)
    {
      return new Mock<T>(name, this, t);
    }

    protected IAction Create(string name)
    {
      return new Mock<string>(name, this, name);
    }

    private class Mock<T> : IAction
    {
      private readonly string myName;
      private readonly ActionTestBase myInstance;
      private readonly T myResult;

      public Mock(string name, ActionTestBase instance, T result)
      {
        myName = name;
        myResult = result;
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
        var context = new Context();
        context.Set(new Key<T>(myName), myResult);
        return context;
      }

      public IAction Clone()
      {
        throw new System.NotImplementedException();
      }
    }
  }
}