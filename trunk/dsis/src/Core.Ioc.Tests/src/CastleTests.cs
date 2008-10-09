using System;
using Castle.MicroKernel;
using NUnit.Framework;

namespace DSIS.Core.Ioc.Tests
{
  [TestFixture]
  public class CastleTests
  {
    private DefaultKernel k;

    [SetUp]
    public void SetUp()
    {
      k = new DefaultKernel();
    }

    [TearDown]
    public void TearDown()
    {
      k = null;
    }

    [Test]
    public void Test_InterfaceService()
    {
      k.AddComponent("ImplA", typeof(IA), typeof(ImplA));
      k.GetService<IA>();
    }

    [Test]
    public void Test_AbstractClassService()
    {
      k.AddComponent("ImplB", typeof(CA), typeof(ImplB));
      k.GetService<CA>();
    }
    
    [Test]
    public void Test_TwoServicesInComponent()
    {
      k.AddComponent("ImplB", typeof(CA), typeof(ImplC));
      k.AddComponent("ImplC", typeof(IA), typeof(ImplC));
      
      k.GetService<CA>();
      k.GetService<IA>();
    } 
    
    [Test]
    public void Test_DifferentInterfaces()
    {
      k.AddComponent("ImplB", typeof(CA), typeof(ImplC));
      k.AddComponent("ImplC", typeof(IA), typeof(ImplC));
      k.AddComponent("ImplCC ", typeof(ImplC));
      
      k.GetService<CA>();
      k.GetService<IA>();
      k.GetService<ImplC>();
    }

    [Test]
    public void Test_MoreThanOneImplTwoServicesInComponent()
    {
      k.AddComponent("ImplQ", typeof(IA), typeof(ImplA));
      k.AddComponent("ImplA", typeof(CA), typeof(ImplB));
      k.AddComponent("ImplB", typeof(CA), typeof(ImplC));
      k.AddComponent("ImplC", typeof(IA), typeof(ImplC));
      
      k.GetService<CA>();
      k.GetService<IA>();

      Console.Out.WriteLine(k.GetService<CA>().GetType());
      Console.Out.WriteLine(k.GetService<IA>().GetType());
    }

    private interface IA {}
    private abstract class CA{}

    private class ImplA : IA {}
    private class ImplB : CA {}
    private class ImplC : CA, IA {}
  }
}
