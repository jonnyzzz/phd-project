using System.Collections.Generic;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;
using System.Linq;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class ProjectEntopryAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> CheckEx<T, Q>(T system, Context ctx)
    {
      if (system.Subdivision.Aggregate(true, (v,x)=>v && x>=2)) {
        return ColBase(base.CheckEx<T, Q>(system, ctx), Create(Keys.GraphMeasure<Q>()));
      }
      return ColBase(base.CheckEx<T, Q>(system, ctx), Create(Keys.GraphMeasure<Q>()),
                     Create(Keys.IntegerCoordinateSystemInfo, "Too small subdivision. Nothing to project"));
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