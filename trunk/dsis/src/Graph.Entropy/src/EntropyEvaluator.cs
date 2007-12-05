using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy
{
  public interface IEntropyLoopBasedEvaluators<T> where T : ICellCoordinate<T>
  {
    IEntropyEvaluator<T> Get(IEntropyLoopWeightCallback cb);
  }

  public static class EntropyEvaluator<T>
    where T : ICellCoordinate<T>
  {
    private class ModelOne : IEntropyLoopBasedEvaluators<T>
    {
      public delegate IEntropyEvaluator<T> Create(IEntropyLoopWeightCallback cb);

      private readonly Create myCreate;

      public ModelOne(Create create)
      {
        myCreate = create;
      }

      public IEntropyEvaluator<T> Get(IEntropyLoopWeightCallback cb)
      {
        return myCreate(cb);
      }
    }

    public static IEntropyLoopBasedEvaluators<T> StrangeModel(StrangeEvaluatorType type, StrangeEvaluatorStrategy strategy, IEntropyLoopWeightCallback cb)
    {
      return new ModelOne(delegate
                            {
                              return new StrangeEntropyEvaluator<T>(cb, type, strategy);
                            });      
    }


    public static IEntropyEvaluator<T> GetJVREvaluator()
    {
      return new JVREvaluator<T>();
    }
  }
}