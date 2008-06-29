using DSIS.Graph.Abstract;
using NUnit.Framework;

namespace DSIS.Graph.Tests.Generic
{
  [TestFixture]
  public class NodeFalgsTest
  {
    private NodeFlags myNodeFlags;
    private NodeFlagValue myValue;

    [SetUp]
    public void SetUp()
    {
      myNodeFlags = new NodeFlags();
      myValue = new NodeFlagValue();
    }

    [TearDown]
    public void TearDown()
    {
      myNodeFlags = null;
    }

    [Test]
    public void Test_HasNoFlags()
    {
      Assert.IsFalse(myValue.GetFlag(NodeFlags.IS_LOOP));
    }

    [Test]
    public void Test_SetResetLoopFlag()
    {
      Assert.IsFalse(myValue.GetFlag(NodeFlags.IS_LOOP));
      myValue.SetFlag(NodeFlags.IS_LOOP, true);
      Assert.IsTrue(myValue.GetFlag(NodeFlags.IS_LOOP));
      myValue.SetFlag(NodeFlags.IS_LOOP, true);
      Assert.IsTrue(myValue.GetFlag(NodeFlags.IS_LOOP));
      myValue.SetFlag(NodeFlags.IS_LOOP, true);
      Assert.IsTrue(myValue.GetFlag(NodeFlags.IS_LOOP));
      myValue.SetFlag(NodeFlags.IS_LOOP, false);
      Assert.IsFalse(myValue.GetFlag(NodeFlags.IS_LOOP));
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
      myValue.SetFlag(NodeFlags.IS_LOOP, true);
      Assert.AreEqual(0, myValue.ComponentId);
      myValue.SetFlag(NodeFlags.IS_LOOP, true);
      Assert.AreEqual(0, myValue.ComponentId);
      myValue.SetComponentId(100);
      Assert.IsTrue(myValue.GetFlag(NodeFlags.IS_LOOP));
      Assert.AreEqual(100, myValue.ComponentId);
      myValue.SetFlag(NodeFlags.IS_LOOP, false);
      Assert.AreEqual(100, myValue.ComponentId);
      Assert.IsTrue(myValue.GetFlag(NodeFlags.IS_LOOP));
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