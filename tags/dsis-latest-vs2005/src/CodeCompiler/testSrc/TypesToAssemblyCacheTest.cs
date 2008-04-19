using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.CodeCompiler
{
  [TestFixture]
  public class TypesToAssemblyCacheTest : TypesToAssemblyCache
  {
    [Test]
    public void Test_01()
    {
      string[] ss = CollectAssemblies(typeof (Test<,,>));
      AssertAeemblies(ss);
    }

    [Test]
    public void Test_02()
    {
      string[] ss = CollectAssemblies(typeof (Test<Hashset<int>, TypesToAssemblyCache, long>));
      AssertAeemblies(ss);
    }

    [Test]
    public void Test_03()
    {
      string[] ss = CollectAssemblies(typeof (Test<,>));
      AssertAeemblies(ss);
    }

    [Test]
    public void Test_04()
    {
      string[] ss = CollectAssemblies(typeof (Test));
      AssertAeemblies(ss);
    }

    private void AssertAeemblies(string[] ss)
    {
      Hashset<string> set = new Hashset<string>();
      set.AddRange(ss);
      Assert.IsTrue(set.Contains(GetType().Assembly.Location));
    }

    public class Test<A,B,C>
    {      
    }

    public class Test<A, B> where A : B where B:new()
    {      
    }    

    public interface Foo<T> {}
    public class Test : Foo<Test> {}
  }
}