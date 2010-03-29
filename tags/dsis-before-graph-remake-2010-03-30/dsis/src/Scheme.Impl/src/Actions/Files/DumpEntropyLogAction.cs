using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;
using DSIS.Utils;
using System.Linq;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class MeasureEntropyLogAction : IntegerCoordinateSystemActionBase3
  {
    private readonly string myPrefix;

    public MeasureEntropyLogAction() : this(string.Empty)
    {
    }

    public MeasureEntropyLogAction(string prefix)
    {
      myPrefix = prefix;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), Create(FileKeys.WorkingFolderKey), Create(Keys.GraphMeasure<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      string dir = FileKeys.WorkingFolderKey.Get(input).Path;
      string file = Path.Combine(Path.GetDirectoryName(dir), "entropy-" + Path.GetFileName(dir) + ".log");

      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      double value = measure.GetEntropy();

      string text = string.Format("{0} edges={1} [{2}] {3}", value.ToString(CultureInfo.InvariantCulture), measure.GetMeasureNodes().Count(), myPrefix, Environment.NewLine);
      File.AppendAllText(file, text);      
    }
  }
}