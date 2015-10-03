using System.Collections.Generic;
using System.Text;
using DSIS.Scheme.Ctx;
using DSIS.Utils;
using System.Linq;

namespace DSIS.Scheme.Ctx
{
  public class Context
  {
    private readonly Dictionary<KeyWrapper, object> myContext;

    private Context(Dictionary<KeyWrapper, object> context)
    {
      myContext = context;
    }

    public Context() : this(new Dictionary<KeyWrapper, object>())
    {
    }
    
    /// <returns>All stored keys without regard to name</returns>
    public IEnumerable<Key<Y>> AllKeys<Y>()
    {
      return myContext.Keys.Filter(x => x.IsKey<Y>()).Convert(x=>x.Cast<Y>());
    }

    public bool ContainsKey<Y>(Key<Y> key)
    {
      return myContext.ContainsKey(KeyWrapper.FromKey(key));
    }

    public Y Get<Y>(Key<Y> key)
    {
      return (Y) myContext[KeyWrapper.FromKey(key)];
    }

    public void Set<Y>(Key<Y> key, Y value)
    {
      myContext[KeyWrapper.FromKey(key)] = value;
    }

    public void Remove<Y>(Key<Y> key)
    {
      myContext.Remove(KeyWrapper.FromKey(key));
    }

    public void AddAll(Context ctx)
    {
      foreach (KeyValuePair<KeyWrapper, object> pair in ctx.myContext)
      {
        myContext[pair.Key] = pair.Value;
      }
    }

    public void AddAllBut(Context ctx, ICollection<IKey> toSkip)
    {
      foreach (KeyValuePair<KeyWrapper, object> pair in ctx.myContext)
      {
        foreach (IKey key in toSkip)
        {
          if (pair.Key.EqualsKey(key))
            continue;          
        }
        
        myContext[pair.Key] = pair.Value;        
      }      
    }
    
    public void AddAllNew(Context ctx)
    {
      foreach (KeyValuePair<KeyWrapper, object> pair in ctx.myContext)
      {
        if (!myContext.ContainsKey(pair.Key))
          myContext[pair.Key] = pair.Value;
      }
    }


    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var pair in myContext)
      {
        sb.AppendFormat("Key: " + pair.Key).AppendLine();
      }
      return sb.AppendLine().ToString();
    }
  }
}