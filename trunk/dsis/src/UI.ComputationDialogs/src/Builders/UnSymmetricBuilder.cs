using DSIS.Core.Builders;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.UI.ComputationDialogs.Builders
{
  internal class UnSymmetricBuilder : ICellImageBuilderWizardResult
  {
    private readonly ICellImageBuilderWizardResult mySymmetric;
    private readonly int myIndex;

    public UnSymmetricBuilder(ICellImageBuilderWizardResult symmetric) : this(symmetric,0)
    {        
    }

    private UnSymmetricBuilder(ICellImageBuilderWizardResult symmetric, int index)
    {
      mySymmetric = symmetric;
      myIndex = index;
    }

    public ICellImageBuilderSettings Setting { get { return mySymmetric.Setting; } }

    public long[] Subdivision { get { return Slice(mySymmetric.Subdivision,myIndex);}}

    public ICellImageBuilderWizardResult Next(Context ctx)
    {
      if (myIndex + 1 < mySymmetric.Subdivision.Length)
        return new UnSymmetricBuilder(mySymmetric, myIndex + 1);
      var next = mySymmetric.Next(ctx);
      if (next == null)
        return null;
      return new UnSymmetricBuilder(next, 0);
    }

    private static long[] Slice(long[] arr, int idx)
    {
      var result = 1L.Fill(arr.Length);
      result[idx] = arr[idx];
      return result;
    }
  }
}