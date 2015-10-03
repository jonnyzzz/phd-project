using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.Graph;
using DSIS.Scheme2.Tests.testData;
using NUnit.Framework;

namespace DSIS.Scheme2.Tests.Xml
{
  public abstract class SchemeGraphBaseTest : SpringBaseTest
  {
    protected SchemeGraphFactory myFactory;

    protected override IEnumerable<Assembly> SpringAssemblies
    {
      get { yield return typeof(SchemeGraph).Assembly; }
    }

    [SetUp]
    public override void SetUp()
    {
      base.SetUp();
      TestGraphRegistry.Clear();
      throw new NotImplementedException();
//      myFactory = myServiceProvider.GetService<SchemeGraphFactory>();
    }    
  }
}