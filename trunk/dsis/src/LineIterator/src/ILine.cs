using System.IO;
using DSIS.Core.System;

namespace DSIS.LineIterator
{
  public interface ILine
  {
    void Iterate(ISystemSpace space, ISystemInfo system);
    void Save(TextWriter tw);

    int Count{ get;}

    double Length { get; }

    ILine Clone();

    int Dimension { get; }
  }
}