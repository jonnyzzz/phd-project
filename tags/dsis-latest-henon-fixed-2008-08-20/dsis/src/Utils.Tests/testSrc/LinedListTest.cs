using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Utils.testSrc
{
  [TestFixture]
  public class LinedListTest
  {
    private LinkedList<int> myList;

    [SetUp]
    public void SetUp()
    {
      myList = new LinkedList<int>();
    }

    [Test]
    public void Test_Add_First()
    {
      for (int i = 1; i < 100; i++)
      {
        myList = new LinkedList<int>();

        for (int j = 0; j < i; j++ )
          myList.AddFront(j);

        Assert.That(myList.IsEmpty, Is.False);
        
        for (int j = i-1; j >=0; j-- )
          Assert.That(myList.RemoveFront(), Is.EqualTo(j));

        Assert.That(myList.IsEmpty, Is.True);
      }
    }
    
    [Test]
    public void Test_Add_Last()
    {
      for (int i = 1; i < 100; i++)
      {
        myList = new LinkedList<int>();

        for (int j = 0; j < i; j++ )
          myList.AddLast(j);

        Assert.That(myList.IsEmpty, Is.False);

        for (int j = 0; j < i; j++)
          Assert.That(myList.RemoveFront(), Is.EqualTo(j));

        Assert.That(myList.IsEmpty, Is.True);
      }
    }

    [Test]
    public void Test_Add_FL()
    {
      for (int i = 1; i < 100; i++)
      {
        myList = new LinkedList<int>();

        for (int j = 1; j <= i; j++)
        {
          myList.AddFront(-j);
          myList.AddLast(j);
        }

        Assert.That(myList.IsEmpty, Is.False);

        for (int j = -i; j <= i; j++)
        {
          if (j == 0)
            continue;

          Assert.That(myList.RemoveFront(), Is.EqualTo(j));
        }

        Assert.That(myList.IsEmpty, Is.True);
      }
    }
  }
}
