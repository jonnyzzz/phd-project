namespace DSIS.Scheme.Ctx
{
  public class SlotStore : Context
  {
    private readonly static SlotStore ourStore = new SlotStore();

    public static readonly Key<SlotStore> KEY = new Key<SlotStore>("SlotStore");

    public static SlotStore Get(Context ctx)
    {
      return ourStore;
    }    
  }
}