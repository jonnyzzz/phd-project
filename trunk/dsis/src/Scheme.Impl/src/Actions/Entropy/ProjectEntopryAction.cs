using System.Collections.Generic;
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
      var measure = Keys.GraphMeasure<Q>().Get(input);
      var divv = Fill(2L, measure.CoordinateSystem.Dimension);
      var project = measure.CoordinateSystem.Project(divv);

      if (project != null)
      {
        var proj = measure.Project(project);
        Keys.GraphMeasure<Q>().Set(output, proj);
        Keys.IntegerCoordinateSystemInfo.Set(output, (IIntegerCoordinateSystemInfo) proj.CoordinateSystem);
      } else
      {
        output.AddAll(input);
      }
    }

    private static T[] Fill<T>(T value, int dim)
    {
      var ts = new T[dim];
      for (int i = 0; i < dim; i++)
        ts[i] = value;
      return ts;
    }
  }
}