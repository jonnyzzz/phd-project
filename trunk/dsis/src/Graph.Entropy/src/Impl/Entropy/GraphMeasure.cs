using System.Collections;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public interface IGraphMeasure<T>

  public class GraphMeasure<T, TPair>
    where T : ICellCoordinate<T>
    where TPair : PairBase<T>  
  {
    public readonly IDictionary<TPair, double> M;
    public readonly IEqualityComparer<T> Comparer;
    public readonly double Norm;

    public GraphMeasure(IDictionary<TPair, double> m, IEqualityComparer<T> comparer, double norm)
    {
      M = m;
      Comparer = comparer;
      Norm = norm;
    }
  }

  public class Dic<T,K> : IDictionary<T, K>
  {
    public bool ContainsKey(T key)
    {
      throw new System.NotImplementedException();
    }

    public void Add(T key, K value)
    {
      throw new System.NotImplementedException();
    }

    public bool Remove(T key)
    {
      throw new System.NotImplementedException();
    }

    public bool TryGetValue(T key, out K value)
    {
      throw new System.NotImplementedException();
    }

    public K this[T key]
    {
      get { throw new System.NotImplementedException(); }
      set { throw new System.NotImplementedException(); }
    }

    public ICollection<T> Keys
    {
      get { throw new System.NotImplementedException(); }
    }

    public ICollection<K> Values
    {
      get { throw new System.NotImplementedException(); }
    }

    public void Add(KeyValuePair<T, K> item)
    {
      throw new System.NotImplementedException();
    }

    public void Clear()
    {
      throw new System.NotImplementedException();
    }

    public bool Contains(KeyValuePair<T, K> item)
    {
      throw new System.NotImplementedException();
    }

    public void CopyTo(KeyValuePair<T, K>[] array, int arrayIndex)
    {
      throw new System.NotImplementedException();
    }

    public bool Remove(KeyValuePair<T, K> item)
    {
      throw new System.NotImplementedException();
    }

    public int Count
    {
      get { throw new System.NotImplementedException(); }
    }

    public bool IsReadOnly
    {
      get { throw new System.NotImplementedException(); }
    }

    IEnumerator<KeyValuePair<T, K>> IEnumerable<KeyValuePair<T, K>>.GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
      return ((IEnumerable<KeyValuePair<T, K>>) this).GetEnumerator();
    }
  }
}