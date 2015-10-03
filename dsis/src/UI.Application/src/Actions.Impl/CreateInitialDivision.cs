using DSIS.Core.Coordinates;
using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;

namespace DSIS.UI.Application.Actions.Impl
{
  [ComponentImplementation]
  public class CreateInitialDivision : IDocumentContextFill
  {
    public string Order
    {
      get { return "00001"; }
    }

    public void FillContext(IReadOnlyContext info, IWriteOnlyContext context)
    {
      var ics = Keys.IntegerCoordinateSystemInfo.Get(info);
      ics.DoGeneric(new WithAction(context));
    }

    private class WithAction : ICellCoordinateWith
    {
      private readonly IWriteOnlyContext myWriteContext;

      public WithAction(IWriteOnlyContext writeContext)
      {
        myWriteContext = writeContext;
      }

      public void With<Q>(ICellCoordinateSystem<Q> system) where Q : ICellCoordinate
      {
        Keys.CellsEnumerationKey<Q>().Set(myWriteContext, system.InitialSubdivision);
      }
    }
  }
}