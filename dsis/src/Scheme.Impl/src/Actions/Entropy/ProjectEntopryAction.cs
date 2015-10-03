using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class ProjectEntopryAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.GraphMeasure<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      long[] divv = Fill(2L, measure.CoordinateSystem.Dimension);
      ICellCoordinateSystemProjector<Q> project = measure.CoordinateSystem.Project(divv);

      if (project != null)
      {
        IGraphMeasure<Q> proj = measure.Project(project);
        Keys.GraphMeasure<Q>().Set(output, proj);
        Keys.IntegerCoordinateSystemInfo.Set(output, (IIntegerCoordinateSystemInfo) proj.CoordinateSystem);
      } else
      {
        output.AddAll(input);
      }
    }

    private static T[] Fill<T>(T value, int dim)
    {
      T[] ts = new T[dim];
      for(int i=0;i<dim; i++)
      {
        ts[i] = value;
      }
      return ts;
    }
  }
}