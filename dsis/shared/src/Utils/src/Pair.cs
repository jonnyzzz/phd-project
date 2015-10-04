namespace EugenePetrenko.Shared.Utils
{
  public static class Pair
  {
    public static Pair<A, B> Of<A, B>(A a, B b)
    {
      return new Pair<A, B>(a, b);
    }
  }

  public class Pair<TA, TB>
  {
    private readonly TA myTA;
    private readonly TB myTB;

    public TA First
    {
      get { return myTA; }
    }

    public TB Second
    {
      get { return myTB; }
    }

    public Pair(TA ta, TB tb)
    {
      myTA = ta;
      myTB = tb;
    }
  }
}