using System.Collections.Generic;
using System.IO;

namespace DSIS.Graph.Abstract
{
  //use type parameter to escape from casting in the StrongComponentInfoBase<T>
  internal interface IStrongComponentInfoEx : IStrongComponentInfo
  {
    IStrongComponentInfoEx Reference { get; }
    new int NodesCount { get; set;}

    bool InsContains(IStrongComponentInfoEx comp);
    IEnumerable<IStrongComponentInfoEx> Ins { get;}
    IEnumerable<IStrongComponentInfoEx> Outs { get;}

    void Dump(TextWriter tw, Dictionary<IStrongComponentInfo, int> comps, ref int cnt);
  }
}