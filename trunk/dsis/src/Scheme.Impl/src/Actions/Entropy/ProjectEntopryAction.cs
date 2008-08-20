using System.Collections.Generic;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class ProjectEntopryAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), Create(Keys.GraphMeasure<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var measure = Keys.GraphMeasure<Q>().Get(input);
      var divv = 2L.Fill(measure.CoordinateSystem.Dimension);
      var project = measure.CoordinateSystem.Project(divv);

      if (project != null)
      {
        var proj = measure.Project(project);
        Keys.GraphMeasure<Q>().Set(output, proj);
        Keys.IntegerCoordinateSystemInfo.Set(output, (IIntegerCoordinateSystem) proj.CoordinateSystem);
      } else
      {
        output.AddAll(input);
      }
    }
  }
}