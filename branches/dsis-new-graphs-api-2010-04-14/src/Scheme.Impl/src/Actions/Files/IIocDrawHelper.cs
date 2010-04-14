using System.Drawing;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public interface IIocDrawHelper
  {
    string DrawImage(Context context, Size sz);
  }
}