using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Scheme.Ctx;

namespace DSIS.UI.ComputationDialogs.Builders
{
  internal class SymmetricBuilder : ICellImageBuilderWizardResult
  {
    private readonly ICellImageBuilderSettings mySettings;
    private readonly long[] mySubdivision;
    private readonly ICollection<ISIComputationConstraint> myConstraints;

    public SymmetricBuilder(ICellImageBuilderSettings settings, long[] subdivision, ICollection<ISIComputationConstraint> constraints)
    {
      mySettings = settings;
      mySubdivision = subdivision;
      myConstraints = constraints;
    }

    public ICellImageBuilderSettings Setting
    {
      get { return mySettings; }
    }

    public long[] Subdivision
    {
      get { return mySubdivision; }
    }

    public ICellImageBuilderWizardResult Next(Context ctx)
    {
      foreach (var constraint in myConstraints)
      {
        if (!constraint.CanContinue(ctx))
          return null;
      }
      return this;        
    }
  }
}