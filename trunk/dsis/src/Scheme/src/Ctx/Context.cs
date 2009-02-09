using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSIS.Utils;

namespace DSIS.Scheme.Ctx
{
  public class Context : IWriteOnlyContext, IReadOnlyContext
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
      return myContext.Keys.Where(x => x.IsKey<Y>()).Map(x=>x.Cast<Y>());
    }

    public Context Clone()
    {
      var ctx = new Context();
      ctx.AddAll(this);
      return ctx;
    }

    public bool ContainsKey<Y>(Key<Y> key)
    {
      return !SearchKeys(key).Where(myContext.ContainsKey).IsEmpty();
    }

    public Y Get<Y>(Key<Y> key)
    {
      foreach (var keyWrapper in SearchKeys(key))
      {
        object val;
        if (myContext.TryGetValue(keyWrapper, out val))
          return (Y)val;        
      }
      throw new ContextException("Key " + key + " was not found in context");
    }

    private IEnumerable<KeyWrapper> SearchKeys<Y>(Key<Y> key)
    {
      yield return KeyWrapper.FromKey(key);

      foreach (var k in myContext.Keys)
      {
        if (!k.OfType<Y>().IsEmpty())
          yield return k;
      }      
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
      foreach (var pair in ctx.myContext)
      {
        foreach (var key in toSkip)
        {
          if (pair.Key.EqualsKey(key))
            continue;          
        }
        
        myContext[pair.Key] = pair.Value;        
      }      
    }
    
    public void AddAllNew(Context ctx)
    {
      foreach (var pair in ctx.myContext)
      {
        if (!myContext.ContainsKey(pair.Key))
          myContext[pair.Key] = pair.Value;
      }
    }

    public delegate bool ReplaceKey(IKey key, object oldValue, object newValue);

    /// <summary>
    /// Adds all key to the context. If same keys contains different values, callback
    /// is called. Values is overriden if callback returns true
    /// </summary>
    /// <param name="ctx">context to add</param>
    /// <param name="keyClashed">Unresolved clash callback</param>
    public void AddAllNew(Context ctx, ReplaceKey keyClashed)
    {
      foreach (KeyValuePair<KeyWrapper, object> pair in ctx.myContext)
      {
        object value;
        if (!myContext.TryGetValue(pair.Key, out value) || pair.Key.Key.Comparer.Equals(value, pair.Value) ||
            keyClashed(pair.Key.Key, value, pair.Value))
        {
          myContext[pair.Key] = pair.Value;
        }
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