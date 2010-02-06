using DSIS.Core.System;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class SelectSystemSpaceWizardFactory
  {
    // ReSharper disable MemberCanBeMadeStatic.Global
    public IWizardPack<ISystemSpace> CreateWizard(ISystemInfo system)
    {
      var model = new FixedDimensionSpaceModel(system.Dimension);

      var space = system as ISystemInfoPreferences;
      if (space != null)
      {
        for (int i = 0; i < system.Dimension; i++)
        {
          ISystemSpace sp = space.PreferredSystemSpace;
          SpaceParametersRowModel rowModel = model.Spaces[i];

          rowModel.Left = sp.AreaLeftPoint[i];
          rowModel.Right = sp.AreaRightPoint[i];
          rowModel.Grid = sp.InitialSubdivision[i];
        }
      }
      return new SelectSystemSpaceWizard(model);
    }
  }
}