using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  public class EntropyGraphWeightCallback<T> : ILoopIteratorCallback<T> where T : ICellCoordinate<T>
  {
    protected readonly Dictionary<NodePair<T>, double> myM =
      new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer());

    private double myNorm = 0;
    protected readonly IEntropyLoopWeightCallback myWeight;

    public EntropyGraphWeightCallback(IEntropyLoopWeightCallback weight)
    {
      myWeight = weight;
    }

    public void OnLoopFound(IList<INode<T>> loop)
    {
      double weight = myWeight.Weight(loop.Count);
      myNorm += weight;

      double p = weight/loop.Count;
      INode<T> prev = null;
      INode<T> first = null;
      foreach (INode<T> node in loop)
      {
        if (prev != null)
        {
          Add(prev.Coordinate, node.Coordinate, p);
        }
        else
        {
          first = node;
        }
        prev = node;
      }
      Add(prev.Coordinate, first.Coordinate, p);
    }

    protected IEnumerable<Pair<NodePair<T>, double>> Weights
    {
      get
      {
        foreach (KeyValuePair<NodePair<T>, double> pair in myM)
        {
          yield return new Pair<NodePair<T>, double>(pair.Key, pair.Value);
        }
      }
    }

    public void ComputeEntropy(IProgressInfo info, IEntropyListener<T> listener)
    {
      EntropyEvaluator<T>.ComputeEntropy(myM, myNorm, info, listener);
    }

    protected void Add(T from, T to, double p)
    {
      double d;
      NodePair<T> pair = new NodePair<T>(from, to);
      myM.TryGetValue(pair, out d);
      myM[pair] = d + p;
    }

    public Dictionary<NodePair<T>, double> M
    {
      get { return myM; }
    }

    public double Norm
    {
      get { return myNorm; }
      protected set { myNorm = value; }
    }
  }
}