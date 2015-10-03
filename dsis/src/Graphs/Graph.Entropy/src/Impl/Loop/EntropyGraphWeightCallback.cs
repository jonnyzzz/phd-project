using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class EntropyGraphWeightCallback<T> : ILoopIteratorCallback<T> 
    where T : ICellCoordinate
  {
    private readonly Dictionary<NodePair<T>, double> myM =
      new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer());

    private double myNorm;
    protected readonly IEntropyLoopWeightCallback myWeight;
    private readonly ICellCoordinateSystem<T> mySystem;

    public EntropyGraphWeightCallback(IEntropyLoopWeightCallback weight, ICellCoordinateSystem<T> system)
    {
      myWeight = weight;
      mySystem = system;
    }

    public void OnLoopFound(IEnumerable<INode<T>> loop, int length)
    {
      double weight = myWeight.Weight(length);
      myNorm += weight;

      double p = weight/length;
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

    protected void Add(T from, T to, double p)
    {
      double d;
      var pair = new NodePair<T>(from, to);
      if (myM.TryGetValue(pair, out d))
      {
        p += d;
      }
      myM[pair] = p;
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

    public IGraphMeasure<T> Entropy()
    {
      return new GraphMeasure<T, NodePair<T>>("Loops", M, EqualityComparerFactory<T>.GetReferenceComparer(), myNorm, mySystem);
    }
  }
}