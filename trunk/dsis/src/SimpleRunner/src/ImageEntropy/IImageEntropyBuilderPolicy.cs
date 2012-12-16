using System;
using System.Collections.Generic;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner.ImageEntropy
{
  public interface IImageEntropyBuilderPolicy
  {
    void ComputeMeasure(ImageEntropyData sys,
                        Func<string, Action<IEnumerable<ImageColor>>> saver,
                        Logger logger);
  }
}