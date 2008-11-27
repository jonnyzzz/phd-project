using System;
using System.Collections.Generic;
using DSIS.Scheme2.ConnectionPoints.Object;
using NUnit.Framework;

namespace DSIS.Scheme2.Tests
{
  [TestFixture]
  public class ActionOutputConnectionPointInferTest
  {
    private class Action : ActionOutputConnectionPoint
    {
      public static Type InferCommonType(object[] os)
      {
        return ActionOutputConnectionPoint.InferCommonType(os);
      }
    }

    public void DoTest(Type expected, params Type[] ins)
    {
      List<object> list = new List<object>();
      foreach (Type type in ins)
      {
        list.Add(Activator.CreateInstance(type));
      }
      Assert.AreEqual(expected, Action.InferCommonType(list.ToArray()));
    }


    [Test]
    public void Test_One()
    {
      DoTest(typeof(B), typeof(B));      
    }
    
    [Test]
    public void Test_Same_1()
    {
      DoTest(typeof(B), typeof(B), typeof(B));      
    }

    [Test]
    public void Test_Same_2()
    {
      DoTest(typeof(B), typeof(B), typeof(B), typeof(B), typeof(B), typeof(B), typeof(B), typeof(B), typeof(B), typeof(B), typeof(B), typeof(B));
    }
        
    [Test]
    public void Test_InferCommon_B_1()
    {
      DoTest(typeof(B), typeof(B1), typeof(B2));      
    }

    [Test]
    public void Test_InferCommon_B_2()
    {
      DoTest(typeof(B), typeof(B1), typeof(B2), typeof(B));      
    }
 
    [Test]
    public void Test_InferCommon_B_3()
    {
      DoTest(typeof(B), typeof(B), typeof(B1), typeof(B2), typeof(B));      
    }
    
    [Test]
    public void Test_InferCommon_B_4()
    {
      DoTest(typeof(B), typeof(B1), typeof(B222));      
    }

    [Test]
    public void Test_InferCommon_B_5()
    {
      DoTest(typeof(B), typeof(B111), typeof(B222));      
    }

    [Test]
    public void Test_InferCommon_B_6()
    {
      DoTest(typeof(B), typeof(B111), typeof(B222), typeof(B));
    }
    
    private class B {}
    private class B1 : B {}
    private class B2 : B {}
    private class B11 : B1 {}
    private class B111 : B11 {}
    private class B22 : B2 {}
    private class B222 : B22 {}
  }
}