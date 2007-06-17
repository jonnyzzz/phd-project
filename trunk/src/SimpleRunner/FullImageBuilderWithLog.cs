using System.IO;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public abstract class FullImageBuilderWithLog<T,Q> : FullImageBuilder<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly string myWorkPath;

    protected FullImageBuilderWithLog(string workPath, long stepLimit, long cellsLimit) : base(stepLimit, cellsLimit)
    {
      myWorkPath = workPath;

      AddListener(new XmlAbstractImageBuilderListener<T,Q>(Path.Combine(myWorkPath, "log.xml")));
      AddListener(new DrawLastComputationResultListener<T,Q>(myWorkPath));
    }
  }
}