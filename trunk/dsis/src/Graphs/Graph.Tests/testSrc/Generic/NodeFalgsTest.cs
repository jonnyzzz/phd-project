using DSIS.Graph.Abstract;
using NUnit.Framework;

namespace DSIS.Graph.Tests.Generic
{
  [TestFixture]
  public class NodeFalgsTest
  {
    private NodeFlags myNodeFlags;
    private NodeFlagValue myValue;
    private NodeFlag FLAG;

    [SetUp]
    public void SetUp()
    {
      myNodeFlags = new NodeFlags();
      myValue = new NodeFlagValue();
      FLAG = myNodeFlags.CreateFlag("FLAG");
    }

    [TearDown]
    public void TearDown()
    {
      myNodeFlags = null;
    }

    [Test]
    public void Test_HasNoFlags()
    {
      Assert.IsFalse(myValue.GetFlag(FLAG));
    }
    
    [Test]
    public void Test_SetResetLoopFlag()
    {
      Assert.IsFalse(myValue.GetFlag(FLAG));
      myValue.SetFlag(FLAG, true);
      Assert.IsTrue(myValue.GetFlag(FLAG));
      myValue.SetFlag(FLAG, true);
      Assert.IsTrue(myValue.GetFlag(FLAG));
      myValue.SetFlag(FLAG, true);
      Assert.IsTrue(myValue.GetFlag(FLAG));
      myValue.SetFlag(FLAG, false);
      Assert.IsFalse(myValue.GetFlag(FLAG));
    }

    [Test]
    public void Test_ComponentId()
    {
      Assert.AreEqual(0, myValue.ComponentId);
    }

    [Test]
    public void Test_ComponentId_change()
    {
      Assert.AreEqual(0, myValue.ComponentId);
      myValue.SetComponentId(100);
      Assert.AreEqual(100, myValue.ComponentId);
    }

    [Test]
    public void Test_ComponentId_change2()
    {
      Assert.AreEqual(0, myValue.ComponentId);
      myValue.SetFlag(FLAG, true);
      Assert.AreEqual(0, myValue.ComponentId);
      myValue.SetFlag(FLAG, true);
      Assert.AreEqual(0, myValue.ComponentId);
      myValue.SetComponentId(100);
      Assert.IsTrue(myValue.GetFlag(FLAG));
      Assert.AreEqual(100, myValue.ComponentId);
      myValue.SetFlag(FLAG, false);
      Assert.AreEqual(100, myValue.ComponentId);
      Assert.IsFalse(myValue.GetFlag(FLAG));
    }

    [Test]
    public void Test_2Falgs()
    {
      var f1 = myNodeFlags.CreateFlag("A");
      var f2 = myNodeFlags.CreateFlag("B");

      Assert.IsFalse(myValue.GetFlag(f1));
      Assert.IsFalse(myValue.GetFlag(f2));

      myValue.SetFlag(f1, false);
      myValue.SetFlag(f2, false);
      Assert.IsFalse(myValue.GetFlag(f1));
      Assert.IsFalse(myValue.GetFlag(f2));

      myValue.SetFlag(f1, true);      
      Assert.IsTrue(myValue.GetFlag(f1));
      Assert.IsFalse(myValue.GetFlag(f2));

      myValue.SetFlag(f2, true);
      Assert.IsTrue(myValue.GetFlag(f1));
      Assert.IsTrue(myValue.GetFlag(f2));
      
      myValue.SetFlag(f1, false);      
      Assert.IsFalse(myValue.GetFlag(f1));
      Assert.IsTrue(myValue.GetFlag(f2));

      myValue.SetFlag(f2, false);
      Assert.IsFalse(myValue.GetFlag(f1));
      Assert.IsFalse(myValue.GetFlag(f2));
    }

    [Test]
    public void Test_ReturnDifferentFlags()
    {
      var f1 = myNodeFlags.CreateFlag("F");
      var f2 = myNodeFlags.CreateFlag("F2");
      var f3 = myNodeFlags.CreateFlag("F3");

      Assert.That(myValue.GetFlag(f1), Is.False);
      Assert.That(myValue.GetFlag(f2), Is.False);
      Assert.That(myValue.GetFlag(f3), Is.False);
      
      myValue.SetFlag(f1, true);
      Assert.That(myValue.GetFlag(f1), Is.True);
      Assert.That(myValue.GetFlag(f2), Is.False);
      Assert.That(myValue.GetFlag(f3), Is.False);

      myValue.SetFlag(f2, true);
      Assert.That(myValue.GetFlag(f1), Is.True);
      Assert.That(myValue.GetFlag(f2), Is.True);
      Assert.That(myValue.GetFlag(f3), Is.False);

      myValue.SetFlag(f3, true);
      Assert.That(myValue.GetFlag(f1), Is.True);
      Assert.That(myValue.GetFlag(f2), Is.True);
      Assert.That(myValue.GetFlag(f3), Is.True);

      myValue.SetFlag(f1, false);
      Assert.That(myValue.GetFlag(f1), Is.False);
      Assert.That(myValue.GetFlag(f2), Is.True);
      Assert.That(myValue.GetFlag(f3), Is.True);

      myValue.SetFlag(f2, false);
      Assert.That(myValue.GetFlag(f1), Is.False);
      Assert.That(myValue.GetFlag(f2), Is.False);
      Assert.That(myValue.GetFlag(f3), Is.True);
    }

    [Test]
    public void Test_ReturnDifferentFlagsComponentId()
    {
      CheckCid(0);

      for(uint i=0; i<5;i++)
      {
        myValue.SetComponentId(i);
        CheckCid(i);
      }
    }

    private void CheckCid(uint cID)
    {
      using(var f1 = myNodeFlags.CreateFlag("F"))
      using(var f2 = myNodeFlags.CreateFlag("F2"))
      using(var f3 = myNodeFlags.CreateFlag("F3"))
      {
        if (f1.IsReusing) myValue.SetFlag(f1, false);
        if (f2.IsReusing) myValue.SetFlag(f2, false);
        if (f3.IsReusing) myValue.SetFlag(f3, false);

        Assert.That(myValue.ComponentId, Is.EqualTo(cID));
        Assert.That(myValue.GetFlag(f1), Is.False);
        Assert.That(myValue.GetFlag(f2), Is.False);
        Assert.That(myValue.GetFlag(f3), Is.False);

        myValue.SetFlag(f1, true);
        Assert.That(myValue.ComponentId, Is.EqualTo(cID));
        Assert.That(myValue.GetFlag(f1), Is.True);
        Assert.That(myValue.GetFlag(f2), Is.False);
        Assert.That(myValue.GetFlag(f3), Is.False);

        myValue.SetFlag(f2, true);
        Assert.That(myValue.ComponentId, Is.EqualTo(cID));
        Assert.That(myValue.GetFlag(f1), Is.True);
        Assert.That(myValue.GetFlag(f2), Is.True);
        Assert.That(myValue.GetFlag(f3), Is.False);

        myValue.SetFlag(f3, true);
        Assert.That(myValue.ComponentId, Is.EqualTo(cID));
        Assert.That(myValue.GetFlag(f1), Is.True);
        Assert.That(myValue.GetFlag(f2), Is.True);
        Assert.That(myValue.GetFlag(f3), Is.True);

        myValue.SetFlag(f1, false);
        Assert.That(myValue.ComponentId, Is.EqualTo(cID));
        Assert.That(myValue.GetFlag(f1), Is.False);
        Assert.That(myValue.GetFlag(f2), Is.True);
        Assert.That(myValue.GetFlag(f3), Is.True);

        myValue.SetFlag(f2, false);
        Assert.That(myValue.ComponentId, Is.EqualTo(cID));
        Assert.That(myValue.GetFlag(f1), Is.False);
        Assert.That(myValue.GetFlag(f2), Is.False);
        Assert.That(myValue.GetFlag(f3), Is.True);

        myValue.SetFlag(f1, true);
        myValue.SetFlag(f2, true);
        myValue.SetFlag(f3, true);
      }
    }


    /*[Test]
    public void TestTarjanNode_01()
    {
      var node = (TarjanNode<Q>)CreateNode();
      ((Node)node).SetComponentId(COMPONENT_ID_TEST);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_02()
    {
      var node = (TarjanNode<Q>)CreateNode();
      ((Node)node).SetFlag(NodeFlags.ROUTE, true);
      ((Node)node).SetComponentId(COMPONENT_ID_TEST);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_03()
    {
      var node = (TarjanNode<Q>)CreateNode();
      ((Node)node).SetComponentId(COMPONENT_ID_TEST);
      ((Node)node).SetFlag(NodeFlags.ROUTE, true);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }

    [Test]
    public void TestTarjanNode_04()
    {
      var node = (TarjanNode<Q>)CreateNode();
      ((Node)node).SetComponentId(COMPONENT_ID_TEST);
      ((Node)node).SetFlag(NodeFlags.ROUTE, true);
      ((Node)node).SetFlag(NodeFlags.STACK, false);
      Assert.AreEqual(COMPONENT_ID_TEST, node.ComponentId);
    }    */
  }
}