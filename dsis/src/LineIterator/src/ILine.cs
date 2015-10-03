using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.System;

namespace DSIS.LineIterator
{
  public interface ILine
  {
    void Iterate(ISystemSpace space, ISystemInfo system);
    
    void Save(TextWriter tw);    

    IEnumerable<ILineVisitor> Points { get; }

    int Count{ get;}

    double Length { get; }

    ILine Clone();

    int Dimension { get; }
  }

  public interface ILineVisitor
  {
    void Visit(Action<double[]> point);
  }
}