using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Utils;

namespace DSIS.Core.Ioc.JC
{
  [JContainerPredefinedComponent]
  public class AttributeScannerImpl : IAttributeScanner
  {
    private readonly JComponentContainerBase myContainer;
    private readonly IAssemblyScaner myScanner;

    public AttributeScannerImpl(JComponentContainerBase container, IAssemblyScaner scanner)
    {
      myContainer = container;
      myScanner = scanner;
    }

    public IEnumerable<Pair<Type, T>> LoadTypes<T>() where T : Attribute
    {
      return myContainer.Assemblies.SelectMany(assembly => myScanner.LoadTypes<T>(assembly));
    }
  }
}