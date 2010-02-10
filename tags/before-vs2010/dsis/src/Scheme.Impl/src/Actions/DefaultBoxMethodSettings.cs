using DSIS.CellImageBuilder.BoxMethod;

namespace DSIS.Scheme.Impl.Actions
{
  public class DefaultBoxMethodSettings : SetMethod2
  {
    public DefaultBoxMethodSettings() : base(BoxMethodSettings.Default, 2)
    {
    }
  }
}