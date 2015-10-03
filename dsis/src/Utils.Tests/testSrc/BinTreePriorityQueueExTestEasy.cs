using System;
using NUnit.Framework;

namespace DSIS.Utils.Tests
{
  [TestFixture]
  public class BinTreePriorityQueueExTestEasy : BinTreePriorityQueueExTestBase
  {
    [Test]
    public void Test_01()
    {
      Assert.AreEqual(null, queue.Min);
    }

    [Test]
    public void Test_02()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual("a", queue.Min);
    }

    [Test]
    public void Test_03()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      Assert.AreEqual("a", queue.Min);
    }

    [Test]
    public void Test_04()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      Assert.AreEqual("b", queue.Min);
    }

    [Test]
    public void Test_05()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      Assert.AreEqual("a", queue.Min);
    }


    [Test]
    public void Test_06()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      Assert.AreEqual("c", queue.Min);
    }

    [Test]
    public void Test_07()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AddNode(4, "d");
      Assert.AreEqual("c", queue.Min);
    }

    [Test]
    public void Test_08()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AddNode(4, "d");
      queue.AddNode(-4, "e");
      Assert.AreEqual("e", queue.Min);
    }

    [Test, ExpectedException(typeof(ArgumentException))]
    public void Test_11()
    {
      queue.ExtractMin();
    }

    [Test]
    public void Test_12()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
    }

    [Test, ExpectedException(typeof(ArgumentException))]
    public void Test_13()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
    }

    [Test]
    public void Test_14()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
    }

    [Test, ExpectedException(typeof(ArgumentException))]
    public void Test_15()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
      queue.ExtractMin();
    }

    [Test]
    public void Test_20()
    {
      queue.AssertConsolidateGroup("[null]");
    }

    [Test]
    public void Test_21()
    {
      queue.AddNode(1, "a");
      queue.AssertConsolidateGroup("0. a(1)", "|", "<null>", "|");
    }

    [Test]
    public void Test_22()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AssertConsolidateGroup("<null>", "|", "0. a(1)", "1. b(2)", "|", "<null>", "|");
    }

    [Test]
    public void Test_23()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AssertConsolidateGroup("0. c(-3)", "|", "0. a(1)", "1. b(2)", "|", "<null>", "|");
    }

    [Test]
    public void Test_24()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AssertConsolidateGroup("<null>", "|", "0. b(-2)", "1. a(1)", "|", "<null>", "|");
    }

    [Test]
    public void Test_25()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");
      queue.AssertConsolidateGroup("0. c(3)", "|", "0. b(-2)", "1. a(1)", "|", "<null>", "|");
    }

    [Test]
    public void Test_26()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");
      queue.AddNode(4, "d");
      queue.AssertConsolidateGroup("<null>", "|", "<null>", "|", "0. b(-2)", "1. a(1)", "1. c(3)", "2. d(4)", "|",
                                   "<null>", "|");
    }

    [Test]
    public void Test_30()
    {
      queue.AssertConsolidate("<null>");
    }

    [Test]
    public void Test_31()
    {
      queue.AddNode(1, "a");
      queue.AssertConsolidate("0. a(1)");
    }

    [Test]
    public void Test_32()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AssertConsolidate("0. a(1)", "1. b(2)");
    }

    [Test]
    public void Test_33()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AssertConsolidate("0. c(-3)", "|", "0. a(1)", "1. b(2)");
    }

    [Test]
    public void Test_34()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AssertConsolidate("0. b(-2)", "1. a(1)");
    }

    [Test]
    public void Test_35()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");
      queue.AssertConsolidate("0. b(-2)", "1. a(1)", "|", "0. c(3)");
    }

    [Test]
    public void Test_36()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");
      queue.AddNode(4, "d");
      queue.AssertConsolidate("0. b(-2)", "1. a(1)", "1. c(3)", "2. d(4)");
    }

    [Test]
    public void Test_x01()
    {
      Add(5);
      object o = Add(4);
      Add(7);      
      queue.AssertConsolidate("0. 4(4)", "1. 5(5)", "|", "0. 7(7)");

      queue.Remove(o);
      queue.AssertQueue("0. 7(7)", "|", "0. 5(5)");      
    }
    
    [Test]
    public void Test_x02()
    {
      Add(5);
      object o = Add(4);
      Add(7);      
      Add(8);      
      queue.AssertConsolidate("0. 4(4)", "1. 5(5)", "1. 7(7)", "2. 8(8)");

      queue.Remove(o);
      queue.AssertQueue("0. 5(5)", "|", "0. 7(7)", "1. 8(8)");      
    }
    
    [Test]
    public void Test_x03()
    {
      Add(5);
      Add(4);
      object o7 = Add(7);      
      object o8 = Add(8);      
      Add(1);      
      Add(2);      
      Add(3);      
      Add(6);      
      queue.AssertConsolidate("0. 1(1)", "1. 2(2)", "1. 4(4)", "2. 5(5)", "2. 7(7)", "3. 8(8)", "1. 3(3)", "2. 6(6)");

      queue.Remove(o8);
      queue.AssertQueue("0. 1(1)", "1. 2(2)", "1. 4(4)", "2. 5(5)", "2. 7(7)", "1. 3(3)", "2. 6(6)");

      queue.Remove(o7);

      queue.AssertQueue("0. 1(1)", "1. 2(2)", "1. 4(4)", "2. 5(5)", "1. 3(3)", "2. 6(6)");
    }
    
    [Test]
    public void Test_x04()
    {
      Add(5);
      Add(4);
      Add(7);      
      Add(8);      
      Add(1);      
      object o2 = Add(2);      
      object o3 = Add(3);      
      Add(6);      
      queue.AssertConsolidate("0. 1(1)", "1. 2(2)", "1. 4(4)", "2. 5(5)", "2. 7(7)", "3. 8(8)", "1. 3(3)", "2. 6(6)");

      queue.Debug();
      queue.Remove(o2);
      queue.Remove(o3);

      queue.AssertQueue("0. 6(6)", "|", "0. 4(4)", "1. 5(5)", "1. 7(7)", "2. 8(8)", "|", "0. 1(1)");      
    }
    
    [Test]
    public void Test_x05()
    {
      Add(5);
      Add(4);
      Add(7);      
      Add(8);      
      Add(1);      
      Add(2);      
      Add(3);      
      Add(6);      
      Add(9);      
      object o10 = Add(10);      
      object o11 = Add(11);      
      Add(12);      
      Add(13);      
      Add(14);      
      Add(15);      
      Add(16);      
      queue.AssertConsolidate("0. 1(1)", "1. 2(2)", "1. 9(9)", "2. 10(10)", "2. 13(13)", "3. 14(14)", 
                              "3. 15(15)", "4. 16(16)", "2. 11(11)", "3. 12(12)", "1. 4(4)", "2. 5(5)",
                              "2. 7(7)", "3. 8(8)", "1. 3(3)", "2. 6(6)");


      queue.Remove(o11);
      queue.Remove(o10);

      queue.AssertQueue("0. 1(1)", "1. 4(4)", "2. 5(5)", "2. 7(7)", "3. 8(8)", "1. 3(3)", "2. 6(6)", "1. 2(2)",
                        "|", "0. 12(12)", "|", "0. 13(13)", "1. 14(14)", "1. 15(15)", "2. 16(16)", "|", "0. 9(9)"
        );

      queue.Debug();
      queue.AssertConsolidate("0. 1(1)", "1. 4(4)", "2. 5(5)", "2. 7(7)", "3. 8(8)", "1. 3(3)", "2. 6(6)", "1. 2(2)",
                              "|", "0. 13(13)", "1. 14(14)", "1. 15(15)", "2. 16(16)", "|", "0. 9(9)", "1. 12(12)");

    }
      
    private object Add(int v)
    {
      return queue.AddNode(v, v.ToString());
    }
  }
}