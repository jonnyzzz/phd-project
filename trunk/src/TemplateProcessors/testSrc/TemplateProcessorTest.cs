using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DSIS.TemplateProcessors.Test
{
  [TestFixture]
  public class TemplateProcessorTest
  {
    [Test]
    public void Test_01()
    {
      Dictionary<string, string> d = new Dictionary<string, string>();
      d.Add("aaa", ">>>");

      string v = "[aaa]bbb]";
      string vv = TemplateProcessor.Substitute(new Template(v), d);

      Assert.AreEqual(">>>bbb]", vv);
    }
    
    [Test]
    public void Test_02()
    {
      Dictionary<string, string> d = new Dictionary<string, string>();
      d.Add("aaa", ">>>");

      string v = "[[[aaa]bbb]]]]]";
      string vv = TemplateProcessor.Substitute(new Template(v), d);

      Assert.AreEqual("[[>>>bbb]]]]]", vv);
    }
    
    [Test]
    public void Test_03()
    {
      Dictionary<string, string> d = new Dictionary<string, string>();
      d.Add("aaa", ">>>");

      string v = @"[[[aaa]


bbb]]]]]


[aaa]";
      string vv = TemplateProcessor.Substitute(new Template(v), d);

      Assert.AreEqual(@"[[>>>


bbb]]]]]


>>>", vv);
    }
  }
}
